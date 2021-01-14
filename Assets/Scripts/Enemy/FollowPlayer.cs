using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int damage;
    [SerializeField] private int hitRange;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isNear = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.ResetTrigger("isAttacking");
        anim.ResetTrigger("isWalking");
        anim.SetTrigger("isIdling");
        if (!isNear)
        {
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isWalking");
            agent.SetDestination(player.position);
        }
        else
        {
            anim.SetTrigger("isAttacking");
        }

        if ((transform.position - player.transform.position).magnitude <= 1)
            isNear = true;
        else
            isNear = false;
    }

    public void OnAttack()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        Vector3 origin = transform.position;
        origin.y += 2;

        if (Physics.Raycast(origin, transform.TransformDirection(Vector3.forward), out hit, hitRange, layerMask))
        {
            Debug.DrawLine(origin, hit.transform.position, Color.red);
            if (hit.transform.gameObject.tag == "Player")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", damage);
                Debug.Log("test");
            }
        }

    }
}

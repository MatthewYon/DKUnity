using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider playerBox;
    [SerializeField] private float speed;
    private Animator anim;
    private Vector3 movement;
    private bool isNear = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.ResetTrigger("isAttacking");
        anim.ResetTrigger("isWalking");
        anim.SetTrigger("isIdling");
        Vector3 direction = player.position - transform.position;
        transform.LookAt(player.position);
        movement = direction;
        if (!isNear)
        {
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isWalking");
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
            anim.SetTrigger("isAttacking");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            isNear = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            isNear = false;
        }
    }
}

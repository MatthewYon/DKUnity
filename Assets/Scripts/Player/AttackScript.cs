using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] int hitRange = 1;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        
    }


    public void OnAttack()
    {
        anim.ResetTrigger("isWalking");
        anim.ResetTrigger("isIdling");
        anim.SetTrigger("isAttacking");

        
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        Vector3 origin = transform.position;
        origin.y += 2;

        if (Physics.Raycast(origin, transform.TransformDirection(Vector3.forward), out hit, hitRange, layerMask))
        {
            Debug.DrawLine(origin, hit.transform.position, Color.red);
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", 30);
            }
        }
        
    }

    private void EndAttack()
    {
        anim.ResetTrigger("isAttacking");
    }
}

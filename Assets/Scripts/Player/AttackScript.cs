using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] int hitRange = 1;
    private bool isAttacking = false;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            int layerMask = 1 << 8;

            layerMask = ~layerMask;

            RaycastHit hit;
            Vector3 origin = transform.position;

            if (Physics.Raycast(origin, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawLine(transform.position, hit.transform.position, Color.red);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.SendMessage("TakeDamage", 30);
                    Debug.Log("HELLOTHERE");
                }
            }
        }
    }


    public void OnAttack()
    {
        anim.ResetTrigger("isWalking");
        anim.ResetTrigger("isIdling");
        anim.SetTrigger("isAttacking");

        isAttacking = true;
    }

    private void EndAttack()
    {
        anim.ResetTrigger("isAttacking");
        isAttacking = false;
    }
}

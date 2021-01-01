using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void OnAttack()
    {
        anim.ResetTrigger("isWalking");
        anim.ResetTrigger("isIdling");
        anim.SetTrigger("isAttacking");
    }

    private void EndAttack()
    {
        anim.ResetTrigger("isAttacking");
    }
}

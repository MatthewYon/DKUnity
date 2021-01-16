using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator anim;
    private MeshCollider mc;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mc = GetComponentInChildren<MeshCollider>();
    }

    public void OnAttack()
    {
        anim.ResetTrigger("isWalking");
        anim.ResetTrigger("isIdling");
        anim.SetTrigger("isAttacking");
    }

    public void Slash()
    {
        mc.enabled = true;
    }

    private void EndAttack()
    {
        anim.ResetTrigger("isAttacking");
        mc.enabled = false;
    }
}

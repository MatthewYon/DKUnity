using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private BoxCollider bc;
    private Animator anim;
    [SerializeField] ScriptableStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponentInChildren<BoxCollider>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
            playerStats.health -= 150;
    }
}

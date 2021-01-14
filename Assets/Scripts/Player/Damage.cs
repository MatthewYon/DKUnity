using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private BoxCollider bc;
    private Animator anim;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] ScriptableStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponentInChildren<BoxCollider>();
        anim = GetComponentInChildren<Animator>();
        healthBar.SetMaxHealth(playerStats.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        playerStats.health -= damage;
        healthBar.SetHealth(playerStats.health);
    }
}

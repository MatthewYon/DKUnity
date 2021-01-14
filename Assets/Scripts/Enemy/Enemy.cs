using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(item, transform.position + Vector3.up, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerStats>().getDamage());
        }
    }
}

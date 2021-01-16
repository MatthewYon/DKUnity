using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] GameObject item;
    [SerializeField] Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = Health;
        slider.value = Health;
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
        slider.value = Health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TakeDamage(other.gameObject.GetComponentInParent<PlayerStats>().getDamage());
        }
    }
}

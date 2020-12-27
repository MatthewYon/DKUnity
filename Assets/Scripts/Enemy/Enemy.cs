using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position - transform.position;
        transform.LookAt(player.transform);
        GetComponent<CharacterController>().SimpleMove(target.normalized * speed * Time.deltaTime);
    }
}

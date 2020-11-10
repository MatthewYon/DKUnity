using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    [SerializeField] int Health = 50;
    private Rigidbody rb;
    private Animator animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 100.0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb.AddForce(new Vector3(playerSpeed, 0, 0) * Time.fixedDeltaTime, ForceMode.Impulse) ;
        }

    }
}

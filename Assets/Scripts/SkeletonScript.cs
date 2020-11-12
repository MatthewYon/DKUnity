using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    public int Health = 50;
    private Rigidbody rb;
    private Animator anim;
    public float playerSpeed = 10.0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            anim.ResetTrigger("isWalking");
            anim.SetTrigger("isIdling");
        }
        else
        {
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isWalking");

            Vector3 targetDirection = new Vector3(moveHorizontal, 0f, moveVertical);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, 15f * Time.deltaTime);

            rb.MoveRotation(newRotation);

            rb.AddForce(moveVertical * Camera.main.transform.forward * playerSpeed);
            rb.AddForce(moveHorizontal * Camera.main.transform.right * playerSpeed);
        }                      
    }
}

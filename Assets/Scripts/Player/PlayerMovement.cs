using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    [SerializeField] private float Speed = 1000f;
    [SerializeField] private float maxSpeed = 100;

    private float AxisX, AxisY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (AxisX == -1 || AxisX == 1 || AxisY == -1 || AxisY == 1)
        {
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isWalking");

            Vector3 targetDirection = new Vector3(AxisX, 0f, AxisY);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, 15f * Time.deltaTime);
            rb.MoveRotation(newRotation);
        }
        else
        {
            anim.ResetTrigger("isWalking");
            anim.SetTrigger("isIdling");
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            Vector3 move = new Vector3(-AxisY, 0f, AxisX);
            move = move.normalized * Time.deltaTime * Speed;
            rb.AddForce(move, ForceMode.Impulse);
        }
    }

    public void OnHorizontal(InputValue value)
    {
        AxisX = value.Get<float>();
    }

    public void OnVertical(InputValue value)
    {
        AxisY = value.Get<float>();
    }
}

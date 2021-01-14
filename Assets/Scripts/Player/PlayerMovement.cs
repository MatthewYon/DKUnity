using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    [SerializeField] private float Speed = 1000f;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private float rotationSpeed = 2f;

    private float AxisX, AxisY;
    private Quaternion rotate;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        rotate = rotate.normalized;
    }

    void Update()
    {
        if (AxisY == 1 || AxisY == -1)
        {
            if (AxisY == 1)
            {
                anim.ResetTrigger("isTurningRight");
                anim.ResetTrigger("isTurningLeft");
                anim.ResetTrigger("isIdling");
                anim.ResetTrigger("isMovingBack");
                anim.SetTrigger("isWalking");
                Vector3 targetDirection = new Vector3(AxisX, 0f, AxisY);
                targetDirection = Camera.main.transform.TransformDirection(targetDirection);
                targetDirection.y = 0.0f;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                rotate = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            else if (AxisY == -1)
            {
                anim.ResetTrigger("isTurningRight");
                anim.ResetTrigger("isTurningLeft");
                anim.ResetTrigger("isIdling");
                anim.ResetTrigger("isWalking");
                anim.SetTrigger("isMovingBack");
                Vector3 targetDirection = new Vector3(AxisX, 0f, 1f);
                targetDirection = Camera.main.transform.TransformDirection(targetDirection);
                targetDirection.y = 0.0f;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                rotate = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        else if(AxisX == 1)
        {
            anim.ResetTrigger("isTurningLeft");
            anim.ResetTrigger("isIdling");
            anim.ResetTrigger("isWalking");
            anim.ResetTrigger("isMovingBack");
            anim.SetTrigger("isTurningRight");
            Vector3 targetDirection = new Vector3(AxisX, 0f, AxisY);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            rotate = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        else if(AxisX == -1)
        {
            anim.ResetTrigger("isTurningRight");
            anim.ResetTrigger("isIdling");
            anim.ResetTrigger("isWalking");
            anim.ResetTrigger("isMovingBack");
            anim.SetTrigger("isTurningLeft");
            Vector3 targetDirection = new Vector3(AxisX, 0f, AxisY);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            rotate = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        else
        {
            anim.ResetTrigger("isTurningLeft");
            anim.ResetTrigger("isTurningRight");
            anim.ResetTrigger("isWalking");
            anim.ResetTrigger("isMovingBack");
            anim.SetTrigger("isIdling");
        }       
    }



    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            Vector3 y = AxisY * Camera.main.transform.forward;
            Vector3 move = y;
            move = move.normalized * Time.deltaTime * Speed;
            rb.AddForce(move, ForceMode.Impulse);
        }
        rb.MoveRotation(rotate);
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

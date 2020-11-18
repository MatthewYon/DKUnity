using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int HealtMax = 50;
    public int Health = 50;
    public int level = 1;
    public int exp;
    public int current_aim_exp = 10;
    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded = true;
    public float playerSpeed = 10.0f;
    public float maxSpeed = 100;
    public float jumpForce = 10.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (exp >= current_aim_exp)
            LevelUp();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        anim.ResetTrigger("isAttacking");
        if (moveHorizontal == 0 && moveVertical == 0 && isGrounded)
        {
            anim.ResetTrigger("isWalking");
            anim.SetTrigger("isIdling");
        }
        else if(isGrounded)
        {
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isWalking");

            Vector3 targetDirection = new Vector3(moveHorizontal, 0f, moveVertical);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, 15f * Time.deltaTime);

            rb.MoveRotation(newRotation);
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(moveVertical * new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z) * playerSpeed * Time.deltaTime, ForceMode.Impulse);
                rb.AddForce(moveHorizontal * new Vector3(Camera.main.transform.right.x, 0.0f, Camera.main.transform.right.z) * playerSpeed * Time.deltaTime, ForceMode.Impulse);
            }

        }
        if (Input.GetKey("space") && isGrounded)
        {
            anim.ResetTrigger("isWalking");
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isJumping");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.ResetTrigger("isWalking");
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isAttacking");
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            anim.ResetTrigger("isJumping");
        }
    }

    private void LevelUp()
    {
        exp -= current_aim_exp;
        HealtMax += 10;
        ++level;
        current_aim_exp += (current_aim_exp / 4);
    }
}

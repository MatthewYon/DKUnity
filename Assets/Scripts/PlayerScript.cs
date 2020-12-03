using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int HealthMax = 50;
    [SerializeField] private int Health = 50;
    [SerializeField] private int level = 1;
    [SerializeField] private int exp;
    [SerializeField] private int current_aim_exp = 10;
    private Rigidbody rb;
    private Animator anim;
    private AudioSource audioSource;
    private bool isGrounded = true;
    [SerializeField] private float playerSpeed = 10.0f;
    [SerializeField] private float maxSpeed = 100;
    [SerializeField] private float jumpForce = 10.0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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



        if (col.gameObject.tag == "Collide")
        {
            Collider myCollider = col.contacts[0].thisCollider;
            if(myCollider.gameObject.GetComponent<MeshCollider>() == gameObject.GetComponentInChildren<MeshCollider>())
            {
                LevelUp();
            }
        }
    }

    private void LevelUp()
    {
        exp -= current_aim_exp;
        HealthMax += 10;
        Health = HealthMax;
        ++level;
        current_aim_exp += (current_aim_exp / 4);
    }
}

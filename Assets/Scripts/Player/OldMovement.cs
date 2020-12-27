/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OldMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded = true;
    [SerializeField] private float playerSpeed = 10.0f;
    [SerializeField] private float maxSpeed = 100;
    [SerializeField] private float jumpForce = 10.0f;
    private PlayerActionsInputs playerActions;
    private float moveHorizontal;
    private float moveVertical;
    private float jump;
    private float attack;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        isGrounded = true;
        moveHorizontal = 0;
        moveVertical = 0;
    }

    private void Update()
    {
        jump = playerActions.Player.Move.ReadValue<float>();
        attack = playerActions.Player.Skill.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Approximately(moveHorizontal,0) && Mathf.Approximately(moveVertical,0) && isGrounded)
        {
            anim.ResetTrigger("isWalking");
            anim.SetTrigger("isIdling");
        }
        else if(isGrounded)
        {
            anim.ResetTrigger("isIdling");
            anim.SetTrigger("isWalking");
            Moves();
        }
        if (jump > 1 && isGrounded)
        {
            Jump();
        }

        if (attack > 1)
        {
            BeginAttack();
        }

    }

    public void Moves()
    {
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

    private void Jump()
    {
        anim.ResetTrigger("isWalking");
        anim.ResetTrigger("isIdling");
        anim.SetTrigger("isJumping");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            anim.ResetTrigger("isJumping");
        }
    }

    public void OnMove(InputValue value)
    {
        moveHorizontal = value.Get<Vector2>().x;
        moveVertical = value.Get<Vector2>().y;
    }

    private void BeginAttack()
    {
        anim.ResetTrigger("isWalking");
        anim.ResetTrigger("isIdling");
        anim.SetTrigger("isAttacking");
    }    
}
*/
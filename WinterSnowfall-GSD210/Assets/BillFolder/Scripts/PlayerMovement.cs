using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundcheck, groundcheck2;
    private Rigidbody2D rb;
    public LayerMask whatIsGround;

    public float moveSpeed;

    public float jumpForce;
    public float jumpBufferLength = 0.1f;
    private float jumpBufferCount;
    public bool grounded;
    private bool lateGrounded;

    public float coyoteTime = 0.2f;
    private float coyoteCounter;

    public Transform cameraTarget;
    public float aheadSpeed;
    public float aheadDistance;

    public float maxJumpHoldTime;
    [SerializeField]
    private float jumpHoldTime;
    
    [SerializeField]
    private bool isJumping;

    [SerializeField]
    private float playerVerticalSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        PlayerState();
        PlayerInput();
        Camera();
        CheckIfPlayerJump();
        CountJumpHoldTime();
        playerVerticalSpeed = rb.velocity.y;
    }
        void LateUpdate()
    {
        IsJumping();
    }
    private void PlayerState()
    {
        //check if player is on the ground
        grounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, whatIsGround) || Physics2D.OverlapCircle(groundcheck2.position, 0.1f, whatIsGround);

        //Jump buffer
        if(Input.GetButtonDown("Jump"))
        {
           jumpBufferCount = jumpBufferLength;
          // isJumping = true;
        }
        else
        jumpBufferCount -= Time.deltaTime;

        //Coyote
        if(grounded)
        {
            coyoteCounter = coyoteTime;
            jumpHoldTime = 0f;
           
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }

        //check if jumping
        if(grounded && rb.velocity.y == 0)
        {
             isJumping = false;
        }
    }

    private void PlayerInput()
    {
         //left right movement
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
    }

    private void Camera()
    {
        //move camera
       if(Input.GetAxisRaw("Horizontal") !=0)
       {
           cameraTarget.localPosition = new Vector3(Mathf.Lerp(cameraTarget.localPosition.x, aheadDistance * Input.GetAxisRaw("Horizontal"), aheadSpeed * Time.deltaTime), cameraTarget.localPosition.y, cameraTarget.localPosition.z);
       }
    
    }

    private void CheckIfPlayerJump()
    {
        //Jump
       if(jumpBufferCount >=0 && coyoteCounter >= 0f)
       {
           
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           jumpBufferCount = 0;
           
       }
    }
    private void CountJumpHoldTime()
    {
        if(Input.GetButton("Jump") && !grounded)
        {
            jumpHoldTime += Time.deltaTime;
        }

        //high jump 
        if(Input.GetButton("Jump") && playerVerticalSpeed >0 && jumpHoldTime < maxJumpHoldTime && isJumping)
        {
             rb.AddForce(Vector2.up * jumpForce);
        }
       
    }

    private void IsJumping()
    {
        if(Input.GetButton("Jump") && lateGrounded)
        {
            isJumping = true;
        }
        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        //frame after player is not grounded this will return true
        lateGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, whatIsGround) || Physics2D.OverlapCircle(groundcheck2.position, 0.1f, whatIsGround);
    }

}
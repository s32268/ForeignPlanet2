using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUpdate : MonoBehaviour
{
    public float moveSpeed = 200;
    public float runSpeed = 7;
    public float jumpForce = 100;
    private bool isSprint = false;
    private bool isJump = false;
    //private bool isCrouch = false;
    //private bool isStandUp = false;
    private float moveVector = 0;
    //private float moveInput = 0;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //moveInput = Input.GetAxis("Horizontal");
        moveVector = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            isJump = true;
            anim.SetBool("Jump", true);
        }
        
       



        if (moveVector != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (rb.velocity.y > 0)
        {
            anim.SetBool("Jump", true);
        }


        if (rb.velocity.y < 0)
        {
            anim.SetBool("JumpDown", true);
            anim.SetBool("Jump", false);
        }

        //dodaj warunek rb.velocity.y < 0 w logice 
        // (czyli w kodzie ustawiasz parametr Fall = true kiedy prędkość Y < -threshold)

        if (rb.velocity.y < 0)
        {
            anim.SetBool("JumpDown", true);
            
        }


        if (rb.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("JumpDown", false);

        }

        if (moveVector > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }

    private void FixedUpdate()
    {
        if (isSprint)
        {
            rb.velocity = new Vector2(moveVector * runSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveVector * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJump = false;
        }
        else
        {
            isJump = false;
        }
    }
}

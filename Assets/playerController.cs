using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float moveSpeed = 5;
    public float runSpeed = 7;
    public float jumpForce = 300;
    public Rigidbody2D rb;
    public GroundCheck groundCheck;
    public PlayerHealth health;
    public Animator anim;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (health.isDead) return;
        
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput >= 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        } 

        if (moveInput != 0)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
        //Debug.Log($"Input value: {moveInput}");
        //rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }

        else

        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        }

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            //rb.AddForce(new Vector2(0,jumpForce));
            rb.AddForce(Vector2.up * jumpForce);

        }

    }
}

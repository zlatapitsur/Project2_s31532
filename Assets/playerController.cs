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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (health.isDead) return;

        float moveInput = Input.GetAxis("Horizontal");

        // Фліп персонажа
        if (moveInput >= 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        // Біг або ходьба
        if (Input.GetKey(KeyCode.LeftShift))
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Анімація бігу
        if (moveInput != 0)
            anim.SetBool("IsRun", true);
        else
            anim.SetBool("IsRun", false);

        // Стрибок
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetBool("IsJump", true);
        }

        // Падіння або приземлення
        if (rb.velocity.y < -0.1f && !groundCheck.isGrounded)
        {
            anim.SetBool("IsFall", true);
        }
        else if (groundCheck.isGrounded)
        {
            anim.SetBool("IsJump", false);
            anim.SetBool("IsFall", false);
        }
    }
}
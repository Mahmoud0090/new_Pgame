using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rd;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float startTimeBetweenselfJumping = 2f;
    [SerializeField] bool reverseMove = false;
    [SerializeField] bool jumpingControl = true;
    [SerializeField] float selfJumpingAddForce = 2f;
    [SerializeField] int numOfMultipleJumps = 2;

    [SerializeField] private TrailRenderer tr;

    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private float timeBetweenJumping;

    private int jumpCounter = 0;

    CircleCollider2D col;
    Animator animator;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        timeBetweenJumping = startTimeBetweenselfJumping;
    }

    public bool ISdashaing()
    {
        return isDashing;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (jumpingControl)
        {
            NormalJumping();
        }
        else
        {
            OutOfControlJumping();
        }
        Move();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        FlipSprite();
    }

    private void Move()
    {
        float HorizontalMove = Input.GetAxisRaw("Horizontal");
        bool hazHorizontalSpeed = Mathf.Abs(rd.velocity.x) > Mathf.Epsilon;

        if (!reverseMove)
        {
            rd.velocity = new Vector2(HorizontalMove * moveSpeed, rd.velocity.y);
            animator.SetBool("isRunning", hazHorizontalSpeed);
        }

        else
        {
            rd.velocity = new Vector2(-HorizontalMove * moveSpeed, rd.velocity.y);
            animator.SetBool("isRunning", hazHorizontalSpeed);
        }
    }

    void FlipSprite()
    {
        bool hazHorizontalSpeed = Mathf.Abs(rd.velocity.x) > Mathf.Epsilon;
        if (hazHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rd.velocity.x), 1f);
        }
    }

    private void NormalJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (col.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rd.velocity = Vector2.up * jumpForce;
                jumpCounter = 1;
            }

            if(!col.IsTouchingLayers(LayerMask.GetMask("Ground")) && jumpCounter < numOfMultipleJumps)
            {
                rd.velocity = Vector2.up * jumpForce;
                jumpCounter++;
            }
        }
    }

    private void OutOfControlJumping()
    {
        if (timeBetweenJumping <= 0)
        {
            if (col.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rd.velocity = Vector2.up * jumpForce * selfJumpingAddForce;
                animator.SetBool("isJumping", true);
            } 
            timeBetweenJumping = startTimeBetweenselfJumping;
        }
        else
        {
            timeBetweenJumping -= Time.deltaTime;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rd.gravityScale;
        rd.gravityScale = 0f;
        rd.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rd.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}

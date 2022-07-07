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
    [SerializeField] float startTimeBetweenJumping = 2f;
    [SerializeField] bool reverseMove = false;
    [SerializeField] bool jumpingControl = true;
    [SerializeField] float selfJumpingAddForce = 2f;

    private float timeBetweenJumping;

    private int jumpCounter = 0;

    BoxCollider2D col;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        timeBetweenJumping = startTimeBetweenJumping;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpingControl)
        {
            NormalJumping();
        }
        else
        {
            OutOfControlJumping();
        }
        Move();
    }

    private void Move()
    {
        float HorizontalMove = Input.GetAxisRaw("Horizontal");

        if (!reverseMove)
        {
            transform.Translate(new Vector2(1, 0) * HorizontalMove * moveSpeed * Time.deltaTime);
        }

        else
        {
            transform.Translate(new Vector2(1, 0) * -HorizontalMove * moveSpeed * Time.deltaTime);
        }
        
    }

    private void NormalJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (col.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                (!col.IsTouchingLayers(LayerMask.GetMask("Ground")) && jumpCounter < 2))
            {
                if (jumpCounter > 1)
                {
                    jumpCounter = 0;
                }
                rd.velocity = Vector2.up * jumpForce;
                jumpCounter++;
            }
        }
    }

    private void OutOfControlJumping()
    {
        if (timeBetweenJumping <= 0 && col.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rd.velocity = Vector2.up * jumpForce * selfJumpingAddForce;
            timeBetweenJumping = startTimeBetweenJumping;
        }
        else
        {
            timeBetweenJumping -= Time.deltaTime;
        }
    }
}

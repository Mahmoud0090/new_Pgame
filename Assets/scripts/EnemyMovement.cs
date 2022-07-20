using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rd;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rd.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
       transform.localScale = new Vector2((Mathf.Sign(rd.velocity.x)), 1f);
    }
}

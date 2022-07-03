using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float timeToExplode = 2;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        StartCoroutine(DestroyBomb());
    }

    IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(timeToExplode);
        Destroy(gameObject);
    }

    private void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Character player;

    private void Start()
    {
        player = FindObjectOfType<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.ISdashaing())
        {
            Destroy(gameObject);
        }
    }
}

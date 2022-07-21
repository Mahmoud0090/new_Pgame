using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<SceneLoader>().RestartScene();
        }

        else if(collision.gameObject.tag == "LiveEnemy")
        {
            bool dashing = GetComponent<Character>().ISdashaing();
            if (!dashing)
            {
                FindObjectOfType<SceneLoader>().RestartScene();
            }
        }
    }
}

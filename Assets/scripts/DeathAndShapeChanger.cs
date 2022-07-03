using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAndShapeChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ShapeChanger")
        {
            if (gameObject.transform.localScale.y <= 0.08) return;
            gameObject.transform.localScale -= new Vector3(0 , 0.5f , 0);
        }

        else if(collision.gameObject.tag == "ShapeSlimmer")
        {
            if (gameObject.transform.localScale.x <= 0.08) return;
            gameObject.transform.localScale -= new Vector3(0.5f, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<SceneLoader>().RestartScene();
        }
    }
}

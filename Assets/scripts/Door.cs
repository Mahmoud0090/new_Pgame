using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    int coinNum;

    private void Start()
    {
        coinNum = FindObjectsOfType<Coin>().Length;
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && coinNum == 0)
        {
            FindObjectOfType<SceneLoader>().NextScene();
        }
    }

    private void Update()
    {
        coinNum = FindObjectsOfType<Coin>().Length;
    }
}

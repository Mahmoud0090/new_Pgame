using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
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

    public int GetCoinNum()
    {
        return coinNum;
    }

    private void Update()
    {
        coinNum = FindObjectsOfType<Coin>().Length;
    }
}

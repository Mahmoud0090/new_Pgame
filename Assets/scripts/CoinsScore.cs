using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScore : MonoBehaviour
{
    [SerializeField] Text coinsText;
    void Start()
    {
        coinsText.text = "Coins : " + FindObjectOfType<Chest>().GetCoinNum().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins : " + FindObjectOfType<Chest>().GetCoinNum().ToString();
    }
}

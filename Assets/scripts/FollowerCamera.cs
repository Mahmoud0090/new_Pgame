using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] GameObject leftLimit;
    [SerializeField] GameObject rightLimit;
    [SerializeField] float limitOffset = 28;
    void Start()
    {
        transform.position = new Vector3(leftLimit.transform.position.x + limitOffset, transform.position.y , -10);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x <= leftLimit.transform.position.x + limitOffset)
        {
            transform.position = new Vector3(leftLimit.transform.position.x + limitOffset, transform.position.y, -10);
        }
        else if(player.transform.position.x >= rightLimit.transform.position.x - limitOffset)
        {
            transform.position = new Vector3(rightLimit.transform.position.x - limitOffset, transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        
    }
}

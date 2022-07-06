using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x , transform.position.y , -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
    }
}

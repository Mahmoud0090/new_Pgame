using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] Transform firePoint;
    [SerializeField] float startTimeBetween;

    float timeBetween;

    void Start()
    {
        timeBetween = startTimeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    private void shoot()
    {
        if (timeBetween <= 0)
        {
            Instantiate(bomb, firePoint.transform.position, firePoint.rotation);
            timeBetween = startTimeBetween;
        }

        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}

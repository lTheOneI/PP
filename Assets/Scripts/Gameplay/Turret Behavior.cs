using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; // Assign the fire point in the Inspector
    public float fireRate = 1.0f; // Time between shots

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
}

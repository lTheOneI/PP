using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    private Transform nearestEnemy;

    public float detectionRadius = 3f;
    public float fireRate;
    public float nexTimeToShoot = 0.1f;
    public float Force = 25f;

    public GameObject bulletPrefab;
    public Transform shootPosition;
    GameObject[] Ants, Butterflies, Beetles;
    GameObject[] enemies;

    Vector2 direction;
    void Update()
    {
        Ants = GameObject.FindGameObjectsWithTag("Ant");
        Butterflies = GameObject.FindGameObjectsWithTag("Butterfly");
        Beetles = GameObject.FindGameObjectsWithTag("Beetle");
            if (Ants.Length != 0)
            {
                enemies = Ants;
            }
            if (Butterflies.Length != 0 && Ants.Length==0) 
            {
                enemies = Butterflies;
            }
            if (Beetles.Length != 0 && Butterflies.Length == 0) 
            {
                enemies = Beetles;
            }
        FindNearestEnemy();
        if (nearestEnemy != null)
        {
            RotateTowardsEnemy();
            if(Time.time > nexTimeToShoot)
            {
                nexTimeToShoot = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    void FindNearestEnemy()
    {
        
        float shortestDistance = Mathf.Infinity;
        GameObject nearest = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearest = enemy;
            }
        }

        if (nearest != null && shortestDistance <= detectionRadius)
        {
            nearestEnemy = nearest.transform;
        }
        else
        {
            nearestEnemy = null;
        }
    }

    void RotateTowardsEnemy()
    {
        direction = nearestEnemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,shootPosition.position, Quaternion.identity );
        bullet.GetComponent<Rigidbody2D>().AddForce(direction*Force);
    }
}

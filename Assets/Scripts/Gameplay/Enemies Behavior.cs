using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{

    private float speed = 0.7f;
    [SerializeField] GameObject coinPrefab;
    private int rate;


    private Vector3 direction;


    void FixedUpdate()
    {
        //Move the Enemies
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        //Create Coin after Enemy Death
        rate= Random.Range(0,2);
        if (rate== 1)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        //Gain Score
        GameLogic.currentScore = GameLogic.currentScore +10;

        //Destroy Enemies
        Destroy(gameObject);
    }
}

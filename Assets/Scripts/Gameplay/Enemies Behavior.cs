using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{

    GameLogic gameLogicScript;
    private float speed = 0.7f;
    [SerializeField] Transform headAnt;
    [SerializeField] GameObject coinPrefab;
    private int rate;


    private Vector3 direction;


    void FixedUpdate()
    {
        //Direct to the target
        gameLogicScript = FindObjectOfType<GameLogic>();
        direction = gameLogicScript.cake.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;  
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

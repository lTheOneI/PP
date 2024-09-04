using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{
    public enum Datatype 
    {
        Ant,
        Butterlfy,
        Beetle
    }

    UIManage uiManageScript;

    private int enemyHealth;
    private float enemyspeed;
    private int rate;
    private int addScore;
    private int enemydamage;

    public Datatype Enemy;
    [SerializeField] GameObject coinPrefab;

    void Start()
    {
        uiManageScript = FindObjectOfType<UIManage>();
        switch (Enemy) 
        {
            case Datatype.Ant:
                enemyHealth = 1;
                enemyspeed = 0.6f;
                addScore = 10;
                enemydamage = 1;
                break;
            case Datatype.Butterlfy:
                enemyHealth = 3;
                enemyspeed = 0.3f;
                addScore = 20;
                enemydamage = 2;
                break;
            case Datatype.Beetle:
                enemyHealth = 3;
                enemyspeed = 0.2f;
                addScore = 20;
                enemydamage = 3;
                break;
        }
    }
    void FixedUpdate()
    {
        //Move the Enemies
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, enemyspeed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        //Destroy Enemies
        enemyHealth--;
            if (enemyHealth <= 0)
            {
                //Create Coin after Enemy Death
                rate = Random.Range(0, 2);
                if (rate == 1)
                {
                    Instantiate(coinPrefab, transform.position, Quaternion.identity);
                }
            
            //Gain Score
            GameLogic.currentScore = GameLogic.currentScore + addScore;
            uiManageScript.soundSource.Play(); 
            Destroy(gameObject);
            }
    }
}

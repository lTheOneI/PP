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
        Beetle,
        Ladybug,
        Boss
    }

    UIManage uiManageScript;

    public int enemyHealth;
    private float enemyspeed;
    private int rate;
    private int addScore;

    [Header("Choose Enemy Type")]
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
                break;
            case Datatype.Butterlfy:
                enemyHealth = 3;
                enemyspeed = 0.3f;
                addScore = 20;
                break;
            case Datatype.Beetle:
                enemyHealth = 3;
                enemyspeed = 0.2f;
                addScore = 20;
                break;
            case Datatype.Ladybug:
                enemyHealth = 3;
                enemyspeed = 1f;
                addScore = 30;
                break;
            case Datatype.Boss:
                enemyHealth = 30;
                enemyspeed = 0.3f;
                addScore = 100;
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
        EnemyBehave();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyBehave();
        }
    }

    void EnemyBehave()
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

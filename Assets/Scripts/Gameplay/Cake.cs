using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Cake : MonoBehaviour
{
    private int maxHealth = 20; 
    public static int currentHealth;
    private UIManage uiManageScript;
    private GameLogic gameLogicScript;

    GameObject[] Ants, Butterflies, Beetles;

    public int enemiesNumber;
    void Start()
    {
        uiManageScript = FindObjectOfType<UIManage>();
        gameLogicScript = FindObjectOfType<GameLogic>();
        currentHealth = maxHealth;
    }

    void Update()
    {
       if (gameLogicScript.waveCount > 3) 
        {
            Ants = GameObject.FindGameObjectsWithTag("Ant");
            Butterflies = GameObject.FindGameObjectsWithTag("Butterfly");
            Beetles = GameObject.FindGameObjectsWithTag("Beetle");
        }

       //Identify number of enemy currently in game
        enemiesNumber = Ants.Length + Butterflies.Length + Beetles.Length;
         if (enemiesNumber <1)
        {
            uiManageScript.finalPanel.SetActive(true);
            uiManageScript.winText.SetActive(true);
        }

    }

    //Collison between cake and enemies
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ant"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Butterfly") 
            || collision.gameObject.CompareTag("Beetle"))
        {
            currentHealth = currentHealth - 3;
            Destroy(collision.gameObject);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        uiManageScript.finalPanel.SetActive(true);
        uiManageScript.loseText.SetActive(true);
        Destroy(gameObject);
    }

    

}

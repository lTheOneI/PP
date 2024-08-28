using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cake : MonoBehaviour
{
    private int maxHealth = 20; 
    public static int currentHealth;
    private UIManage UIManageScript;



    void Start()
    {
        currentHealth = maxHealth; 
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ant"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Butterfly"))
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
        DestroyObjectWithTag();
        UIManageScript = FindObjectOfType<UIManage>();
        UIManageScript.losePanel.SetActive(true);
        Destroy(gameObject);
    }

    void DestroyObjectWithTag()
    {
        GameObject[] Ants = GameObject.FindGameObjectsWithTag("Ant");
        foreach (GameObject obj in Ants)
        {
            Destroy(obj);
        }
    }

}

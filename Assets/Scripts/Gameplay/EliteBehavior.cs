using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EliteBehavior : MonoBehaviour
{
    GameLogic gameLogicScript;
    public enum Bosstype
    {
        Beetles,
        Ladybug,
        Boss
    }
    [Header("Choose Boos Types")]
    public Bosstype Types;
    void OnDestroy()
    {
        switch (Types)
        {
            case Bosstype.Beetles:
                for(int i = 0; i < 10; i++)
                {
                    Instantiate(gameLogicScript.antPrefab, transform.position, Quaternion.identity);
                }
                break;
            case Bosstype.Ladybug:
                for (int i = 0; i< 7; i++)
                {
                    Instantiate(gameLogicScript.butterflyPrefab, transform.position, Quaternion.identity);
                }
                break;
            case Bosstype.Boss:
                for (int i = 0;i < 5;i++) 
                {
                    Instantiate(gameLogicScript.beetlePrefab, transform.position, Quaternion.identity);
                }
                break;
        }
    }
}

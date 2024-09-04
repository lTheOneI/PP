using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    GameLogic gameLogicScript;

    public enum Bosses
    {
        Beetle,
        Ladybug,
        Boss
    }

    public Bosses BossType;

    private void OnDestroy()
    {
        switch (BossType)
        {
            case Bosses.Beetle:
                for(int i = 0; i<10; i++)
                {
                    Instantiate(gameLogicScript.antPrefab, transform.position, Quaternion.identity);
                }
                break;
            case Bosses.Ladybug:
                for (int i = 0; i<10; i++)
                {
                    Instantiate(gameLogicScript.butterflyPrefab, transform.position, Quaternion.identity);
                }
                break;
            case Bosses.Boss:
                for (int i=0; i<10; i++)
                {
                    Instantiate(gameLogicScript.beetlePrefab, transform.position, Quaternion.identity);
                }
                break;
        }
    }
}

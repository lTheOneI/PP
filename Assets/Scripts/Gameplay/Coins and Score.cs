using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsandScore : MonoBehaviour
{
    
    GameLogic gameLogicScript;

    private void OnMouseDown()
    {
        GameLogic.coins++;
        Debug.Log("CoinCollected");
        Destroy(this.gameObject);
    }

}

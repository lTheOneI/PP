using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CoinsandScore : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("UICoin");
    }
    private void OnMouseDown()
    {
        transform.DOMove(target.transform.position, 1f);
        GameLogic.coins++;
        Debug.Log("CoinCollected");
        Destroy(this.gameObject,1.2f);
    }


}

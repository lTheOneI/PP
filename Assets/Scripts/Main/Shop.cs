using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;

    public Items_Scriptable Items;

    private void OnEnable()
    {
        Instantiate(shopPanel);
    }

}

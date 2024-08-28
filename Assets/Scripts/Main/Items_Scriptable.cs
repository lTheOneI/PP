using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ShopItems")] 
public class Items_Scriptable : ScriptableObject
{

    public string name;
    public string description;
    public int price;

    public Sprite artwork;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemDisplay : MonoBehaviour
{
    public Items_Scriptable itemin4;
    public TMP_Text priceItem;
    public TMP_Text descriptionItem;
    public TMP_Text nameItem;
    void Start()
    {
        priceItem.text = itemin4.price.ToString();
        descriptionItem.text = itemin4.description;
        nameItem.text = itemin4.name;
    }

}

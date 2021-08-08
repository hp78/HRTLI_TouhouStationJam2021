using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSO : ScriptableObject
{
    [Space(5)]
    public bool isUnlocked;
    public string itemName;
    public Image itemSprite;
    public int price;
    [Space(5)]
    public string flavorText;
}
     
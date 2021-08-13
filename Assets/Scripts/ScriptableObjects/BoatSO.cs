using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Boat", order = 1)]
public class BoatSO : ItemSO
{
    [Space(5)]
    public int maxWeight;
    public Sprite fowardSprite;
    public Sprite backSprite;
    public override string GetItemDescChunk()
    {
        return "" + flavorText + "\n\n"
            + "Max Weight " + maxWeight + "\n";
    }
}

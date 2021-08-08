using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Cooler", order = 1)]
public class CoolerSO : ItemSO
{
    [Space(5)]
    public int timeBonus;

    public override string GetItemDescChunk()
    {
        return "" + flavorText + "\n\n"
            + "Endurance " + timeBonus + "\n";
    }
}

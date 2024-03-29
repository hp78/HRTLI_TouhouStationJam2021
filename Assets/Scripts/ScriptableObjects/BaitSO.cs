using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Bait", order = 1)]
public class BaitSO : ItemSO
{
    [Space(5)]
    public int baitSpeed;
    public int baitMaxFish;

    public override string GetItemDescChunk()
    {
        return "" + flavorText + "\n\n"
            + "Bait Speed " + baitSpeed + "\n"
            + "Bait Strength " + baitMaxFish + "\n";
    }
}

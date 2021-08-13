using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Rod", order = 1)]
public class RodSO : ItemSO
{
    [Space(5)]
    public int diveSpeed;
    public int reelSpeed;
    public int fastReelSpeed;

    public Sprite UpperRod;
    public Sprite LowerRod;

    public override string GetItemDescChunk()
    {
        return "" + flavorText + "\n\n"
            + "Dive Speed " + diveSpeed + "\n"
            + "Reel Speed " + reelSpeed + "\n"
            + "Fast Reel Speed " + fastReelSpeed + "\n";
    }
}

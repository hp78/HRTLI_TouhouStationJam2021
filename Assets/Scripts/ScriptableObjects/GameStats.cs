using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : ScriptableObject
{
    public int currStageProgress;
    public int currMoney;

    public int currBoatIndex;
    public int currRodIndex;
    public int currBaitIndex;
    public int currCoolerIndex;

    public List<ItemSO> boatList;
    public List<ItemSO> rodList;
    public List<ItemSO> baitList;
    public List<ItemSO> coolerList;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/GameStat", order = 1)]
public class GameStatSO : ScriptableObject
{
    [Space(5)]
    public int currStageProgress;
    public int currMoney;

    [Space(5)]
    public ItemSO currBoat;
    public ItemSO currRod;
    public ItemSO currBait;
    public ItemSO currCooler;

    [Space(5)]
    public int currBoatIndex;
    public int currRodIndex;
    public int currBaitIndex;
    public int currCoolerIndex;

    [Header("Items")]
    public List<ItemSO> boatList;
    public List<ItemSO> rodList;
    public List<ItemSO> baitList;
    public List<ItemSO> coolerList;

    [Header("Fish bestiary")]
    public List<FishSO> fishList;
}

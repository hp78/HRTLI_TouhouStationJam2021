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
    public BoatSO currBoat;
    public RodSO currRod;
    public BaitSO currBait;
    public CoolerSO currCooler;

    [Space(5)]
    public int currBoatIndex;
    public int currRodIndex;
    public int currBaitIndex;
    public int currCoolerIndex;

    [Header("Items")]
    public List<BoatSO> boatList;
    public List<RodSO> rodList;
    public List<BaitSO> baitList;
    public List<CoolerSO> coolerList;

    [Header("Fish bestiary")]
    public List<FishSO> fishList;
}

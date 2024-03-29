using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/PlayerStat", order = 1)]
public class PlayerStatSO : ScriptableObject
{
    public int currWeight;
    public int currTime;

    public List<FishSO> caughtFish;

    public void ClearStats()
    {
        currWeight = 0;
        caughtFish.Clear();
    }

}



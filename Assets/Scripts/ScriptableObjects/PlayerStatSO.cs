using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/PlayerStat", order = 1)]
public class PlayerStatSO : ScriptableObject
{
    public int currWeight;
    public int maxWeight;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Fish", menuName = "ScriptableObjects/Fish", order = 1)]
public class FishSO : ScriptableObject
{
    public string fishName;
    public float spawnRate;
    public float weight;
}


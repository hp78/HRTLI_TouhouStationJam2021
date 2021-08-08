using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Fish", menuName = "ScriptableObjects/Fish", order = 1)]
public class FishSO : ScriptableObject
{
    public bool hasCaught;

    [Space(5)]
    public string fishName;
    public Sprite fishSprite;
    public float spawnRate;
    public float weight;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapController : MonoBehaviour
{
    public GameStatSO gameStats;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= gameStats.currStageProgress; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

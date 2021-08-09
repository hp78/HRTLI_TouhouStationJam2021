using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageItemScript : MonoBehaviour
{
    public int stageIndex = 1;
    public int stageCost = 500;
    public Image stageImage;
    public TMP_Text stageNameText;
    public TMP_Text stageCostText;
    public Button unlockButton;

    [Space(5)]
    public GameStatSO gameStat;

    // Start is called before the first frame update
    void Start()
    {
        if(gameStat.currStageProgress + 1 < stageIndex)
        {
            unlockButton.interactable = false;
            stageCostText.text = stageCost.ToString();
        }
        else if(gameStat.currStageProgress > stageIndex)
        {
            unlockButton.interactable = false;
            stageCostText.text = "";
        }
        else
        {
            unlockButton.interactable = true;
            stageCostText.text = stageCost.ToString();
        }
    }

    public void UnlockStage(int stageIndex)
    {
        if (gameStat.currMoney >= stageCost)
        {
            gameStat.currMoney -= stageCost;
            gameStat.currStageProgress = stageIndex;
        }
    }
}

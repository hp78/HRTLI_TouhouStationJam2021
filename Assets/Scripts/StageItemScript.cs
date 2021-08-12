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
    public Image stageDarken;
    public TMP_Text stageNameText;
    public TMP_Text stageCostText;
    public Button unlockButton;
    public SuikaShopManager suikaShopManager;

    [Space(5)]
    public GameStatSO gameStat;

    // Start is called before the first frame update
    void Start()
    {
        UpdateButtons();
    }

    public void UnlockStage(int stageIndex)
    {
        if (gameStat.currMoney >= stageCost)
        {
            gameStat.currMoney -= stageCost;
            gameStat.currStageProgress = stageIndex;

            suikaShopManager.UpdateAllStages();
        }
    }

    public void UpdateButtons()
    {
        if (gameStat.currStageProgress >= stageIndex)
        {
            unlockButton.interactable = false;
            stageCostText.text = "";
            unlockButton.gameObject.SetActive(false);
            stageDarken.gameObject.SetActive(false);
        }
        else if (gameStat.currStageProgress + 1 == stageIndex)
        {
            unlockButton.interactable = true;
            stageCostText.text = stageCost.ToString();
            unlockButton.gameObject.SetActive(true);
            stageDarken.gameObject.SetActive(true);
        }
        else
        {
            unlockButton.interactable = false;
            stageCostText.text = stageCost.ToString();
            unlockButton.gameObject.SetActive(true);
            stageDarken.gameObject.SetActive(true);
        }

    }
}

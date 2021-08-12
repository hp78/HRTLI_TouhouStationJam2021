using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuikaShopManager : MonoBehaviour
{
    public GameStatSO gameStat;
    public TMP_Text moneyText;
    public List<StageItemScript> sicList;

    private void Start()
    {
        UpdateMoney();
    }
    public void UpdateMoney()
    {
        moneyText.text = "" + gameStat.currMoney;
    }

    public void UpdateAllStages()
    {
        UpdateMoney();
        foreach (StageItemScript sic in sicList)
        {
            sic.UpdateButtons();
        }
    }
}

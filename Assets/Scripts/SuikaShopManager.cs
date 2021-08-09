using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuikaShopManager : MonoBehaviour
{
    public GameStatSO gameStat;
    public TMP_Text moneyText;


    public void UpdateMoney()
    {
        moneyText.text = "$" + gameStat.currMoney;
    }
}

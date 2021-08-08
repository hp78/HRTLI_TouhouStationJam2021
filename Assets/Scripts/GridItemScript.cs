using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridItemScript : MonoBehaviour
{
    public GameStatSO gameStat;
    public ItemSO itemSO;

    [Space(5)]
    public Image itemImage;
    public Button buyButton;
    public TMP_Text tmpEquippedText;

   public void Init(ItemSO nItemSO)
    {
        itemSO = nItemSO;
    }

    public void SelectItem()
    {
        if(itemSO == ShopController.instance.currSelectItem && itemSO.isUnlocked)
        {
            ShopController.instance.SetShopEquippedItem(itemSO);
        }
        else
        {
            ShopController.instance.currSelectItem = itemSO;
        }

        ShopController.instance.RefreshAllItems();
    }

    public void BuyItem()
    {
        if(gameStat.currMoney >= itemSO.price)
        {
            gameStat.currMoney -= itemSO.price;
            itemSO.isUnlocked = true;
        }

        ShopController.instance.RefreshAllItems();
    }

    public void RefreshItem()
    {
        if (itemSO.isUnlocked)
            buyButton.gameObject.SetActive(false);
        else
            buyButton.gameObject.SetActive(true);
    }
}

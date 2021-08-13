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
    public Image gridItemImage;
    public Image itemImage;
    public Button buyButton;
    public TMP_Text tmpPriceText;
    public TMP_Text tmpEquippedText;

    private void Start()
    {
        tmpPriceText.text = itemSO.price.ToString();
        gridItemImage.sprite = itemSO.itemSprite;
    }
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
            ShopController.instance.SelectItem(itemSO);
        }

        ShopController.instance.RefreshAllItems();
    }

    public void BuyItem()
    {
        ShopController.instance.PurchaseItem(itemSO);
    }

    public void RefreshItem()
    {
        buyButton.gameObject.SetActive(!itemSO.isUnlocked);
        tmpEquippedText.gameObject.SetActive(itemSO == ShopController.instance.GetShopEquippedItem());
    }
}

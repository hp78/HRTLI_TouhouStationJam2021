using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public static ShopController instance;
    public enum ShopType { BAIT, BOAT, COOLER, ROD };
    public ShopType shopType = ShopType.BAIT;

    [Space(5)]
    public GameObject pfShopItem;
    public List<GridItemScript> gisList;
    public GameStatSO gameStat;

    [Space(5)]
    public Transform shopItemContent;

    [Space(5)]
    public Image itemSprite;
    public TMP_Text tmpItemName;
    public TMP_Text tmpItemDesc;

    [Space(5)]
    public Button buyButton;
    public TMP_Text tmpBuyText;
    public TMP_Text tmpPriceText;

    [Space(5)]
    public TMP_Text tmpCurrCashText;
    public ItemSO currSelectItem;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gisList = new List<GridItemScript>();
        CreateItems();
    }

    void CreateItems()
    {
        foreach(ItemSO i in GetShopItemList())
        {
            GameObject go = Instantiate(pfShopItem, shopItemContent);
            GridItemScript gis = go.GetComponent<GridItemScript>();
            gisList.Add(gis);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectItem(ItemSO item, bool isOwned)
    {
        itemSprite.sprite = item.itemSprite;
        tmpItemName.text = item.itemName;
        if(isOwned)
        {
            buyButton.interactable = false;
            tmpBuyText.text = "Owned";
            tmpPriceText.text = "";
        }
        else
        {
            buyButton.interactable = true;
            tmpBuyText.text = "Buy";
            tmpPriceText.text = "$" +item.price;
        }
        //tmpItemDesc =;
    }

    public List<ItemSO> GetShopItemList()
    {
        switch(shopType)
        {
            case ShopType.BAIT:
                return gameStat.baitList;

            case ShopType.ROD:
                return gameStat.rodList;

            case ShopType.BOAT:
                return gameStat.boatList;

            case ShopType.COOLER:
                return gameStat.coolerList;

            default:
                return gameStat.baitList;
        }
    }

    public ItemSO GetShopEquippedItem()
    {
        switch (shopType)
        {
            case ShopType.BAIT:
                return gameStat.currBait;

            case ShopType.ROD:
                return gameStat.currRod;

            case ShopType.BOAT:
                return gameStat.currBoat;

            case ShopType.COOLER:
                return gameStat.currCooler;

            default:
                return gameStat.currBait;
        }
    }

    public void SetShopEquippedItem(ItemSO itemSO)
    {
        switch (shopType)
        {
            case ShopType.BAIT:
                gameStat.currBait = itemSO;
                break;

            case ShopType.ROD:
                gameStat.currRod = itemSO;
                break;

            case ShopType.BOAT:
                gameStat.currBoat = itemSO;
                break;

            case ShopType.COOLER:
                gameStat.currCooler = itemSO;
                break;

            default:
                gameStat.currBait = itemSO;
                break;
        }
    }

    public void RefreshAllItems()
    {
        foreach(GridItemScript gis in gisList)
        {
            gis.RefreshItem();
        }
    }
}

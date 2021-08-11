using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookController : MonoBehaviour
{
    public GameStatSO gameStats;
    public PlayerStatSO playerStat;
    SpriteRenderer spriteRend;
    BoxCollider2D col2D;

    Text uiText;
    
    int weightLimit = 0;
    int currentWeight = 0;

    public List<FishSO> listOfFish;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        col2D = GetComponent<BoxCollider2D>();

        uiText = GameObject.Find("WeightText").GetComponent<Text>();

        weightLimit = ((BaitSO)gameStats.currBait).baitMaxFish;
        UpdateUI();
    }

    public void SetVisible(bool isVisible)
    {
        spriteRend.enabled = isVisible;
    }

    public void SetCollider(bool canCollide)
    {
        if (currentWeight <= weightLimit)
            col2D.enabled = canCollide;
    }

    public void ClearWeight()
    {
        currentWeight = 0;
        col2D.enabled = true;
        foreach(FishSO i in listOfFish)
        {
            playerStat.caughtFish.Add(i);
            playerStat.currWeight += i.weight;
        }
        listOfFish.Clear();
        UpdateUI();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fish"))
        {
            FishAIController temp = collision.GetComponent<FishAIController>();
            currentWeight += temp.fishSOStats.weight;
            temp.gameObject.SetActive(false);
            listOfFish.Add(temp.fishSOStats);

            if (currentWeight>weightLimit)
            {
                col2D.enabled = false;
                listOfFish.Clear();

                SetVisible(false);
            }
            UpdateUI();

        }
    }


    void UpdateUI()
    {
        if (!col2D.enabled)
        {
            uiText.text = "OVERLOADED BITCH";
            uiText.color = Color.red;
        }
        else
        {
            uiText.text = currentWeight + "/" + weightLimit;
            uiText.color = Color.white;

        }

    }
}

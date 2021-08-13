using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuikaWinController : MonoBehaviour
{

    public PlayerStatSO playerSO;
    public GameStatSO gameStats;
    public Button nextButton;
    public TextMeshProUGUI moneyText;
    public AudioSource kaching;
    public Image fishSprite;
    public TextMeshProUGUI fishName;
    public TextMeshProUGUI fishValue;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = gameStats.currMoney.ToString();
        StartCoroutine(CheckInFish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckInFish()
    {
        foreach(FishSO i in playerSO.caughtFish)
        {
            gameStats.currMoney += i.value;
            moneyText.text = gameStats.currMoney.ToString();
            fishSprite.sprite = i.fishPrefab.GetComponentInChildren<SpriteRenderer>().sprite;
            fishName.text = i.fishName;
            fishValue.text = "Value: $" + i.value.ToString(); ;
            kaching.Play();

            yield return new WaitForSeconds(0.5f);

        }
        nextButton.interactable = true;
        playerSO.ClearStats();
        yield return 0;
    }
}

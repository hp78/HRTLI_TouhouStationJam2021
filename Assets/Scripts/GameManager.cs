using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text temperatureText;
    public RectTransform tempMarker;
    public Text baitWeightText;
    public Text boatWeightText;
    public Text depthText;
    public Transform depthIcon;

    public GameStatSO gameStat;
    public PlayerController player;

    public int stageDuration;
    float timer;

    int baitWeightLimit = 0;
    int boatWeightLimit = 0;

    float heightIncreasement;
    float yIncreasement;

    float tempIncreament;
    float currtemp;

    public GameObject endScreen;
    public Text endText;

    bool stageEnd = false;




    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        baitWeightLimit = ((BaitSO)gameStat.currBait).baitMaxFish;
        boatWeightLimit = ((BoatSO)gameStat.currBoat).maxWeight;

        stageDuration += ((CoolerSO)gameStat.currCooler).timeBonus;

        yIncreasement = (5f + 85f) / stageDuration;
        heightIncreasement = (180f - 1f) / stageDuration;
        tempIncreament = 100f / stageDuration;

        currtemp = 0;
        timer = 0;
        stageEnd = false;


        UpdateBaitText(0);
    }

    public void UpdateBaitText(int weight)
    {

        if(weight > baitWeightLimit)
        {
            baitWeightText.text = "Line Snapped!";
            baitWeightText.color = Color.red;
        }
        else
        {
            baitWeightText.text = weight + "/" + baitWeightLimit;
            baitWeightText.color = Color.white;
        }
        UpdateBoatText();
    }

    public void UpdateBoatText()
    {
        boatWeightText.text = player.playerStat.currWeight + "/" + boatWeightLimit;

        if (player.playerStat.currWeight > boatWeightLimit)
        {
            endText.text = "Your boat has reached its weight limit!";
            EndStage();
        }

        if (stageEnd) EndStage();

    }

    public void UpdateTime()
    {
        tempMarker.anchoredPosition = new Vector2(tempMarker.anchoredPosition.x, tempMarker.anchoredPosition.y + yIncreasement * Time.deltaTime);
        tempMarker.sizeDelta = new Vector2(tempMarker.sizeDelta.x, tempMarker.sizeDelta.y + heightIncreasement * Time.deltaTime);
        timer += Time.deltaTime;

        currtemp += tempIncreament * Time.deltaTime;
        int tempInt = (int)currtemp;
        temperatureText.text = tempInt.ToString();
    }

    private void Update()
    {

        if (timer < stageDuration && !stageEnd)
        {
            UpdateTime();
        }
        else
        {
            stageEnd = true;
            endText.text = "Your boat is too hot!";
            if (player.currState == PlayerController.PlayerState.IDLE) EndStage();
        }
    }

    void EndStage()
    {
        endScreen.SetActive(true);
        player.enabled = false;
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameStatSO gameStat;

    public ItemSO startBoat;
    public ItemSO startRod;
    public ItemSO startBait;
    public ItemSO startCooler;

    [Space(5)]
    public GameObject resetButton;

    // Start is called before the first frame update
    void Start()
    {
        if(gameStat.currStageProgress == 5)
        {
            resetButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            ResetGameStat();
    }

    public void StartGame()
    {
        if(gameStat.hasLaunchedGame)
        {
            SceneManager.LoadScene("WorldMap");
        }
        else
        {
            ResetGameStat();
            gameStat.hasLaunchedGame = true;
            SceneManager.LoadScene("IntroScene");
        }
    }

    public void ResetGameStat()
    {
        gameStat.hasLaunchedGame = false;

        gameStat.currStageProgress = 0;
        gameStat.currMoney = 100;

        gameStat.currBoat = startBoat;
        gameStat.currRod = startRod;
        gameStat.currBait = startBait;
        gameStat.currCooler = startCooler;
    }
}

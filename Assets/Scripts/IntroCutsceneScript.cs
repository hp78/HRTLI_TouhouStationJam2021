using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutsceneScript : MonoBehaviour
{
    //
    public void StartGame()
    {
        SceneManager.LoadScene("WorldMap");
    }
}

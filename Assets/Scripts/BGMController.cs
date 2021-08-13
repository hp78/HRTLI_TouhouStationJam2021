using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{

    public AudioSource titleBgm;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch(sceneName)
        {
            case "MainMenu":
            case "TownMap":
            case "WorldMap":
            case "IntroScene":
            case "EndingScene":
                if (!titleBgm.isPlaying) titleBgm.Play();
                break;
            default:
                titleBgm.Stop();
                break;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text temperatureText;
    public Text weightText;
    public Text depthText;
    public Transform depthIcon;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}

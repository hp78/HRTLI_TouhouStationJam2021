using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditScript : MonoBehaviour
{
    public TMP_Text roles;
    public TMP_Text memeRoles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleRole(bool isOn)
    {
        roles.gameObject.SetActive(isOn);
        memeRoles.gameObject.SetActive(!isOn);
    }
}

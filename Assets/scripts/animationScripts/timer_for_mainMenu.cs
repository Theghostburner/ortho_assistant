using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_for_mainMenu : MonoBehaviour
{
    public GameObject panelLogo,panelMain;
    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>3f)
        {
            panelLogo.SetActive(false);
            panelMain.SetActive(true);
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class ModifyEnd : MonoBehaviour
{
    private GameObject toggle1;
    private GameObject toggle2;
    public bool end;
    

    private void Start()
    {
        toggle1 = GameObject.FindWithTag("Toggle1");
        toggle2 = GameObject.FindWithTag("Toggle2");
        toggle2.GetComponent<Toggle>().isOn = false;
    }

    private void Update()
    {
        end = toggle2.GetComponent<Toggle>().isOn;
        /*if (end)
        {
            toggle1.SendMessage("TurnOff");
        }*/
    }
    
    void TurnOff()
    {
        toggle2.GetComponent<Toggle>().isOn = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class ModifyEnd : MonoBehaviour
{
    private GameObject toggle;
    public bool end;

    private void Start()
    {
        toggle = GameObject.FindWithTag("Toggle2");
    }

    private void Update()
    {
        end = toggle.GetComponent<Toggle>().isOn;
    }
}

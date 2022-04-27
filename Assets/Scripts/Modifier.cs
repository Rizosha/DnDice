using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Modifier : MonoBehaviour
{
    public int modifier;
    public TMP_InputField field;

    private void Update()
    {
        ModToInt();
    }

    public void ModToInt()
    {
        modifier = int.Parse(field.text);
    }
}

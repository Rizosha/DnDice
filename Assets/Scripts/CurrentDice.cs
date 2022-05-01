using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDice : MonoBehaviour
{
    public GameObject[] currentDiceList;
    public int indexHowMany;
    public int d4, d6, d8, d10, d12, d20, d100; 

    private void Update()
    {
//        AddDiceToList();
    }

    void AddDiceToList()
    {
        Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
    }

    void ClearDiceArray()
    {
        
    }
    
}

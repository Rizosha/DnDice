using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DiceDisplay : MonoBehaviour
{

    [Header("Dice Output Options",order = 1)]
    public TextMeshProUGUI roll;
    public int modifier;
    public int allDiceOutput;
    public bool calculateEnd;
    public bool all;
     
    [Header("Current Dice Lists",order = 2)]
    public int[] diceNumbers;
    public bool[] diceMoving;
   
    [Header("Script Grabbing",order = 3)]
    public Modifier mod;
    public ModifyEnd toggle;
    public ButtonSpawns customList;
  
    void Start()
    {
        customList = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
        mod = GameObject.FindWithTag("Modifier").GetComponent<Modifier>();
        toggle = GameObject.FindWithTag("Toggle2").GetComponent<ModifyEnd>();
    }
    
    void Update()
    {
        //sets modifier amount
        modifier = mod.modifier;

        //toggle button
        calculateEnd = toggle.end;
        
        // resize dice output array to meet custom list
        Array.Resize( ref diceMoving, customList.currentDiceList.Length);
        for (int i = 0; i < diceMoving.Length; i++)
        {
            diceMoving[i] = customList._currentDice[i].GetComponent<DiceManager>().hasStopped;
        }

        // check if all the dice in array have stopped moving 
        all = diceMoving.All(c => c == true);

        if (all)
        {
            // resize dice output array to meet custom list
            Array.Resize( ref diceNumbers, customList.currentDiceList.Length);
        
            //set each number from dice into an array
            for (int i = 0; i < customList._currentDice.Count; i++)
            {
                diceNumbers[i] = customList._currentDice[i].GetComponent<DiceManager>().diceOutput;
            }
            //calculate array
            allDiceOutput = diceNumbers.Sum();
            
            //if end modifier checked, add modifier to the dice output
            if (calculateEnd)
            {
                allDiceOutput = diceNumbers.Sum() + modifier;
            }
        }
        //output all dice into ui text
       roll.text = allDiceOutput.ToString();
    }

 
}

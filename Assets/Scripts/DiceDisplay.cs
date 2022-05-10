using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class DiceDisplay : MonoBehaviour
{

    public DiceManager diceNumber;

    public TextMeshProUGUI roll;
    public ButtonSpawns customList;
    public int allDiceOutput;

    public int howManyTru;
    //should be true again when thrown
    public bool canCalculate;
    public int[] diceNumbers;
    public bool[] diceMoving;
    public bool all;

    public bool calculateEnd;
    public Modifier mod;
    public int modifier;
    public ModifyEnd toggle;
    //public bool ;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        customList = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
        mod = GameObject.FindWithTag("Modifier").GetComponent<Modifier>();
        toggle = GameObject.FindWithTag("Toggle2").GetComponent<ModifyEnd>();

    }

    // Update is called once per frame
    void Update()
    {
        //sets modifier amount
        modifier = mod.modifier;

        calculateEnd = toggle.end;

       
        
        
        // resize dice output array to meet custom list
        Array.Resize( ref diceMoving, customList.currentDiceList.Length);
        for (int i = 0; i < diceMoving.Length; i++)
        {
            diceMoving[i] = customList._currentDice[i].GetComponent<DiceManager>().hasStopped;
        }

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
            
            if (calculateEnd)
            {
                allDiceOutput = diceNumbers.Sum() + modifier;
            }

        }
        
        
       //roll.text = diceNumber.diceOutput.ToString();

       //output all dice into ui text
       roll.text = allDiceOutput.ToString();
    }

 
}

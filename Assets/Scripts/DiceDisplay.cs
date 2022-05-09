using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceDisplay : MonoBehaviour
{

    public DiceManager diceNumber;

    public TextMeshProUGUI roll;
    public ButtonSpawns customList;
    public int allDiceOutput;

    public int howManyTru;
    //should be true again when thrown
    public bool canCalculate;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        diceNumber = GameObject.FindWithTag("D6").GetComponent<DiceManager>();
        customList = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (diceNumber.diceStopped == customList._currentDice.Count && canCalculate)
        {
            for (int i = 0; i < customList._currentDice.Count; i++)
            {
                allDiceOutput += customList._currentDice[i].GetComponent<DiceManager>().diceOutput;
            }
*            
        }*/

        if (canCalculate) 
        {
           for (int i = 0; i < customList._currentDice.Count; i++)
           {
               allDiceOutput += customList._currentDice[i].GetComponent<DiceManager>().diceOutput;
           }

           canCalculate = false;
        }
        
       //roll.text = diceNumber.diceOutput.ToString();

       roll.text = allDiceOutput.ToString();
    }
}

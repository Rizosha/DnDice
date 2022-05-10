using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DiceManager : MonoBehaviour
{
    public Transform[] sides;
    public float[] sidesY;
    public float topValueY;
    public int diceOutput;
    public bool allMod;
    public int modifier;
    public Modifier mod;
    public ModifyAll modAll;

    public float diceVel;

    public DiceDisplay display;
    //change to true when thrown
    public bool canDisplay = true;

    public bool hasStopped;
    

    private void Start()
    {
        mod = GameObject.FindWithTag("Modifier").GetComponent<Modifier>();
        modAll = GameObject.FindWithTag("Toggle1").GetComponent<ModifyAll>();
        display = GameObject.FindWithTag("Display").GetComponent<DiceDisplay>();
    }

    void Update()
    {
        // shows the velocity of the dice in editor
        diceVel = gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        //DiceUpdate();
        // if the dice velocity is 0, output the dice number
        if (canDisplay && diceVel == 0)
        {
            
                DiceUpdate();
                hasStopped = true;
                canDisplay = false;
            

        }
        else
        {
            diceOutput = 0;
            hasStopped = false;
        }
        
        
        

    }

    private void DisplayUpdate()
    {
        display.allDiceOutput += diceOutput;
    }

    private void DiceUpdate()
    {
        // the int modifier
        modifier = mod.modifier;
        //toggle bool
        allMod = modAll.all;
        
        // get position of dice sides
        for (int i = 0; i < sides.Length; i++)
        {
            sidesY[i] = sides[i].transform.position.y;
            if( i == sides.Length)
            {
                i = 0;
            }
        }
        topValueY = sidesY.Max();
        if (allMod)
        {
            diceOutput = sidesY.ToList().IndexOf(topValueY) + 1 + modifier;
        }
        else
        {
            diceOutput = sidesY.ToList().IndexOf(topValueY) + 1;
        }
       
        if (gameObject.CompareTag("D100"))
        {
            diceOutput = diceOutput * 10;
        }

        
    }


    void DestroyDice()
    {
        Destroy(gameObject);
    }
}

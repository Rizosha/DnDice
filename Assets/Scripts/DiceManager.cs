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
    

    private void Start()
    {
        mod = GameObject.FindWithTag("Modifier").GetComponent<Modifier>();
        modAll = GameObject.FindWithTag("Toggle1").GetComponent<ModifyAll>();
        display = GameObject.FindWithTag("Display").GetComponent<DiceDisplay>();
    }

    void Update()
    {
        diceVel = gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        if (diceVel == 0 && canDisplay)
        {
            
            DiceUpdate();
            DisplayUpdate();
            canDisplay = false;
            /*for (int i = 0; i < display.Length; i++)
            {
                display[i].SetActive(true);
            }*/
        }
        
        

    }

    private void DisplayUpdate()
    {
        display.allDiceOutput += diceOutput;
    }

    private void DiceUpdate()
    {
        modifier = mod.modifier;
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

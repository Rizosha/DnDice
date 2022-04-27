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

    private void Start()
    {
        mod = GameObject.FindWithTag("Modifier").GetComponent<Modifier>();
        modAll = GameObject.FindWithTag("Toggle1").GetComponent<ModifyAll>();
    }

    private void Update()
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
}

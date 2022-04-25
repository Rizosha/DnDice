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
    
    

    private void Update()
    {
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
        diceOutput = sidesY.ToList().IndexOf(topValueY) + 1;
        if (gameObject.CompareTag("D100"))
        {
            diceOutput = diceOutput * 10;
        }
    } 
}

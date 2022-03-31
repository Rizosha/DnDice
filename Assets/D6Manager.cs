using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class D6Manager : MonoBehaviour
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
        // some check to see if the dice is moving 
        //topValueY = Math.Max(sidesY[sidesY.Length], sidesY[sidesY.Length]);
        topValueY = sidesY.Max();
        diceOutput = sidesY.ToList().IndexOf(topValueY) + 1;      
        // return the game object no. with largest Y position
    } 
}

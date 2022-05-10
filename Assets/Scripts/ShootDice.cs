using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.PlayerLoop;
using Random = System.Random;


public class ShootDice : MonoBehaviour
{
   public GameObject dice;
   public Rigidbody diceRb;
   
  
   public float dVeloc;
   public float dRotSpd;
   private float pingPong, pingPong2;
   public float cameraDist;
   private Touch sling;
   private Vector3 touchStart, touchEnd, direction,wtouchStart,wtouchEnd;

   private bool shootF = false;
   public ButtonSpawns diceList;

   public DiceManager[] diceBool;

   public DiceDisplay diceDisplay;
   public bool dbool;
  


   public void Start()
   {
       diceList = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
       diceDisplay = GameObject.FindWithTag("Display").GetComponent<DiceDisplay>();
   }

   void Update()
    {
        // sets the velocity variable
        dVeloc = diceRb.velocity.magnitude;
        
        //set size of array
        Array.Resize(ref diceBool,diceList.currentDiceList.Length);
        // grabs dice scripts for array
        for (int i = 0; i < diceList.currentDiceList.Length; i++)
        {
            diceBool[i] = diceList._currentDice[i].GetComponent<DiceManager>();
        }
        
       //if you input 1 touch
        if (Input.touchCount == 1)
        {
            diceDisplay.allDiceOutput = 0;
            GetInputDirections();
            //MoveDiceToFinger();
           // ShootDiceFromFinger();
            GatherDice();
            RotateObject();
        }
        
        // if you release finger, fire object 
        if (sling.phase == TouchPhase.Ended)
        {
            shootF = true;
            StartCoroutine(waitToSetCanDisplay());
            dbool = true;
            // set can display to true to enable dice calculation
            /*foreach (var t in diceBool)
            {
                t.canDisplay = true;
            }*/
            
            //ShootDiceFromFinger();
           // ShootEm();
            
        }
        

        // set dbool to true to enable dice calculation
        if (dbool)
        {
            StartCoroutine(waitToSetCanDisplay());
            /*foreach (var t in diceBool)
            {
                t.canDisplay = true;
            }*/

            dbool = false;
        }
    }

   public void GatherDice()
   {
       // loops through current dice and sets the position of dice at finger and 
       for (int i = 0; i < diceList.currentDiceList.Length; i++)
       {
           Rigidbody cDice = diceList.currentDiceList[i].GetComponent<Rigidbody>();
           cDice.transform.position = wtouchEnd;
           
           //this was its own method in fixed update at the end of touch, but it imitates what i want more here than what i created
           // adds a force to current dice in list
           diceList.currentDiceList[i].AddForce(transform.TransformDirection(direction * 3f), ForceMode.Impulse);
          
       }
   }

   public void FixedUpdate()
   {
       /*if (shootF)
       {
           ShootEm();
       }*/
   }

   void GetInputDirections()
   {
       //sling is the slingshot mechanic
       sling = Input.GetTouch(0);
           
       //create touch reference positions on touch events
       if (sling.phase == TouchPhase.Began)
       {
           touchStart = sling.position;
           touchEnd = sling.position;
       }else if (sling.phase == TouchPhase.Moved || sling.phase == TouchPhase.Ended)
       {
           touchEnd = sling.position;
       }
       
       // converts touch points into world points
       wtouchStart = Camera.main.ScreenToWorldPoint(new Vector3(touchStart.x,touchStart.y,cameraDist));
       wtouchEnd = Camera.main.ScreenToWorldPoint(new Vector3(touchEnd.x,touchEnd.y,cameraDist));
       
            
       // using the given points, create a direction to fire object
       direction = wtouchStart - wtouchEnd;
       Debug.DrawRay(dice.transform.position,direction,Color.green);
   }

   public void RotateObject()
   {
       //create a ping pong number to create a multiplication
       pingPong = Mathf.Lerp(2f,6f, Mathf.PingPong(Time.time / 4  ,1 ));
       pingPong2 = Mathf.Lerp(6f, -6f, Mathf.PingPong(Time.time / 4, 1));

       for (int i = 0; i < diceList.currentDiceList.Length; i++)
       {
           
           // sets the dice velocity to 0 so the dice doesn't gain momentum when held
           diceList.currentDiceList[i].velocity = Vector3.zero;
           diceList.currentDiceList[i].angularVelocity = Vector3.zero;
           
           //add a torque based on ping pong. Ping pong allows a number to be negative and positive to imitate a left, right, up and down motion 
           diceList.currentDiceList[i].AddTorque(transform.up * dRotSpd * pingPong);
           diceList.currentDiceList[i].AddTorque(transform.right * dRotSpd * pingPong2);
       }
       
   }

   public void ShootEm()
   {
       for (int i = 0; i < diceList.currentDiceList.Length; i++)
       {
           diceList.currentDiceList[i].AddForce(transform.TransformDirection(direction * 5f), ForceMode.Impulse);
       }

   }


    IEnumerator waitToSetCanDisplay()
    {
        yield return 30;
        foreach (var t in diceBool)
        {
            t.canDisplay = true;
        }
    }
    
}

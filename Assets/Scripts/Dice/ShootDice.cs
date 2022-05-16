using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class ShootDice : MonoBehaviour
{
   [Header("Dice Values",order = 1)]
   public float dRotSpd;
   public float pingPong, pingPong2;
   public float cameraDist;
   private Touch touchSling;
   private Vector3 touchStart, touchEnd, direction,wtouchStart,wtouchEnd;
   private Vector3 pcTouchStart, pcTouchEnd;

   [Header("Dice Boolean List ",order = 2)]
   public DiceManager[] diceBool;
   public bool dbool;
   
   [Header("Script Grabbing",order = 3)]
   public DiceDisplay diceDisplay;
   public ButtonSpawns diceList;
   
   public void Start()
   {
       diceList = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
       diceDisplay = GameObject.FindWithTag("Display").GetComponent<DiceDisplay>();
   }

   void Update()
    {
        //set size of array
        Array.Resize(ref diceBool,diceList.currentDiceList.Length);
        
        //Grabs dice scripts for array
        for (int i = 0; i < diceList.currentDiceList.Length; i++)
        {
            diceBool[i] = diceList._currentDice[i].GetComponent<DiceManager>();
        }
        
        //If you input 1 touch
        if (Input.touchCount == 1)
        {
            diceDisplay.allDiceOutput = 0;
            GetInputDirections();
            GatherDice();
            RotateObject();
        }
        
        //If you release finger, fire object 
        if (touchSling.phase == TouchPhase.Ended)
        {
            StartCoroutine(waitToSetCanDisplay());
            dbool = true;
        }
        
        //Set dbool to true to enable dice calculation
        if (dbool)
        {
            StartCoroutine(waitToSetCanDisplay());
            dbool = false;
        }
    }

   public void GatherDice()
   {
       //Loops through current dice and sets the position of dice at finger and 
       for (int i = 0; i < diceList.currentDiceList.Length; i++)
       {
           Rigidbody cDice = diceList.currentDiceList[i].GetComponent<Rigidbody>();
           cDice.transform.position = wtouchEnd;
           
           //This was its own method in fixed update at the end of touch, but it imitates what i want more here than what i created
           
           // Adds a force to current dice in list
           diceList.currentDiceList[i].AddForce(transform.TransformDirection(direction * 3f), ForceMode.Impulse);
       }
   }

   void GetInputDirections()
   {
       //Sling is the slingshot mechanic
       touchSling = Input.GetTouch(0);
       
       //Create touch reference positions on touch events
       if (touchSling.phase == TouchPhase.Began )
       {
           touchStart = touchSling.position;
           touchEnd = touchSling.position;
          
       }else if (touchSling.phase == TouchPhase.Moved || touchSling.phase == TouchPhase.Ended)
       {
           touchEnd = touchSling.position;
       }
       
       //Converts touch points into world points
       wtouchStart = Camera.main.ScreenToWorldPoint(new Vector3(touchStart.x,touchStart.y,cameraDist));
       wtouchEnd = Camera.main.ScreenToWorldPoint(new Vector3(touchEnd.x,touchEnd.y,cameraDist));
      
       
       //Using the given points, create a direction to fire object
       direction = wtouchStart - wtouchEnd;
       
   }

   public void RotateObject()
   {
       //Create a ping pong number to create a multiplication
       pingPong = Mathf.Lerp(2f,6f, Mathf.PingPong(Time.time / 4  ,1 ));
       pingPong2 = Mathf.Lerp(6f, -6f, Mathf.PingPong(Time.time / 4, 1));

       for (int i = 0; i < diceList.currentDiceList.Length; i++)
       {
           //Sets the dice velocity to 0 so the dice doesn't gain momentum when held
           diceList.currentDiceList[i].velocity = Vector3.zero;
           diceList.currentDiceList[i].angularVelocity = Vector3.zero;
           
           //Add a torque based on ping pong. Ping pong allows a number to be negative and positive to imitate a left, right, up and down motion 
           diceList.currentDiceList[i].AddTorque(transform.up * dRotSpd * pingPong);
           diceList.currentDiceList[i].AddTorque(transform.right * dRotSpd * pingPong2);
       }
       
   }
   //Ensures that it calculates once instead of every frame
    IEnumerator waitToSetCanDisplay()
    {
        yield return 30;
        foreach (var t in diceBool)
        {
            t.canDisplay = true;
        }
    }
}

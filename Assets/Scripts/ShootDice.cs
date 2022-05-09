using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.PlayerLoop;


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

   public GameObject shooterPointMain;
   public Transform[] shooterPoints;

   public ButtonSpawns diceList;
   public Rigidbody[] currentDiceRb;
   public int arraySize;


   public void Start()
   {
       diceList = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
   }

   void Update()
    {
        // sets the velocity variable
        dVeloc = diceRb.velocity.magnitude;
        
       //if you input 1 touch
        if (Input.touchCount == 1)
        {
            GetInputDirections();
            
            /*GameObject d6 = DicePooling.SharedInstance.GetPooledObject(); 
              if (d6 != null) {
                d6.transform.position = wtouchEnd;
                d6.SetActive(true);
              }*/
            diceRb.transform.position = wtouchEnd;
            
            shooterPointMain.transform.position = wtouchEnd;
            shooterPointMain.transform.LookAt(direction);
            
            //MoveDiceToFinger();
              
            ShootDiceFromFinger();
            
              RotateObject();
        }
        
        // if you release finger, fire object 
        if (sling.phase == TouchPhase.Ended)
        {
            shootF = true;
            StartCoroutine(forceTime());
            //ShootDiceFromFinger();
            
        }
    }

   public void ShootDiceFromFinger()
   {
       for (int i = 0; i < diceList.currentDiceList.Length; i++)
       {
           Rigidbody cDice = diceList.currentDiceList[i].GetComponent<Rigidbody>();
           cDice.transform.position = wtouchEnd;
           diceList.currentDiceList[i].AddForce(transform.TransformDirection(direction * 5f), ForceMode.Impulse);
       }
   }

   public void FixedUpdate()
   {
       if (shootF)
       {
           diceRb.AddForce(transform.TransformDirection(direction * 5f), ForceMode.Impulse);
       }
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
           diceList.currentDiceList[i].velocity = Vector3.zero;
           diceList.currentDiceList[i].angularVelocity = Vector3.zero;
           diceList.currentDiceList[i].AddTorque(transform.up * dRotSpd * pingPong);
           diceList.currentDiceList[i].AddTorque(transform.right * dRotSpd * pingPong2);
       }
       
   }
   
    IEnumerator forceTime()
    {
        yield return 50;
        shootF = false;
    }
    
}

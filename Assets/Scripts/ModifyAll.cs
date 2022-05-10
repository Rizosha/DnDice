using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

public class ModifyAll : MonoBehaviour
{
   public bool all;
  
   private GameObject toggle;
   private GameObject toggle2;

   private void Start()
   {
       toggle = GameObject.FindWithTag("Toggle1");
       toggle2 = GameObject.FindWithTag("Toggle2");
       toggle.GetComponent<Toggle>().isOn = false;
   }

   private void Update()
   {
       all = toggle.GetComponent<Toggle>().isOn;
       /*if (all)
       {
           toggle2.SendMessage("TurnOff");
       }*/
   }

   void TurnOff()
   {
       toggle.GetComponent<Toggle>().isOn = false;
   }

  
}

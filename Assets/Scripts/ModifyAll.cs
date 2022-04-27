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

   private void Start()
   {
       toggle = GameObject.FindWithTag("Toggle1");
   }

   private void Update()
   {
       all = toggle.GetComponent<Toggle>().isOn;
   }

   /*public void ToggleSound()
   {
       all = tog.isOn;
   }*/

  
}

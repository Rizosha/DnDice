using UnityEngine;
using Toggle = UnityEngine.UI.Toggle;

public class ModifyAll : MonoBehaviour
{
    /// <summary>
    /// Sets a boolean for the All toggle
    /// </summary>
   
   public bool all;
   private GameObject toggle;
 
   private void Start()
   {
       toggle = GameObject.FindWithTag("Toggle1");
       toggle.GetComponent<Toggle>().isOn = false;
   }

   private void Update()
   {
       all = toggle.GetComponent<Toggle>().isOn;
   }

   void TurnOff()
   {
       toggle.GetComponent<Toggle>().isOn = false;
   }

  
}

using TMPro;
using UnityEngine;

public class SpellText : MonoBehaviour
{
   /// <summary>
   /// Settings to display the spells field
   /// </summary>
   
   public string currentText;
   public TMP_InputField field;
   public ButtonSpawns bSaveText;

   private void Start()
   {
      bSaveText = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
   }

   public void SaveString()
   {
      currentText = field.text;
      bSaveText.spellText = currentText;
   }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnSavedDice : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTextArr;
    public GameObject[] buttonArr;

    SaveDice saveDice;

    private void Start()
    {
        // Initialize the saveDice reference
        saveDice = GetComponent<SaveDice>();

        ChangeButtonName();
    }

    public void ChangeButtonName()
    {
        // Assuming you have an array of TMP GUIs named "buttons" and a reference to the SaveDice script named "saveDice"

        // Get the spell list from the SaveDice script
        List<SaveDice.SpellData> spellList = saveDice.LoadSpellData();

        // Iterate over the buttons array and assign the spell names
        for (int i = 0; i < buttonTextArr.Length; i++)
        {
            // Check if there is a corresponding spell data in the list
            if (i < spellList.Count)
            {
                // Assign the spell name to the button
                buttonTextArr[i].text = spellList[i].spellName;

                // Check if there is an entry at the same array/list position as the SaveDice
                if (spellList[i].spellName != "")
                {
                    // Set the button game object to active
                    buttonArr[i].gameObject.SetActive(true);
                }
                else
                {
                    // Set the button game object to inactive
                    buttonArr[i].gameObject.SetActive(false);
                }
            }
            else
            {
                // If there are no more spell data in the list, clear the button name
                buttonTextArr[i].text = "";

                // Set the button game object to inactive
                buttonArr[i].gameObject.SetActive(false);
            }
        }
    }
}

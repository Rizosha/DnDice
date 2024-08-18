using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnSavedDice : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTextArr;
    public GameObject[] buttonArr;
    public ButtonSpawns buttonSpawns;

    SaveDice saveDice;

    private void Start()
    {
        // Initialize the saveDice reference
        saveDice = GetComponent<SaveDice>();
        buttonSpawns = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();

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

    public void SpawnSaveDice(int index)
    {
        // Load existing spells
        List<SaveDice.SpellData> spellList = saveDice.LoadSpellData();

        // Check if the index is within the bounds of the spell list
        if (index >= 0 && index < spellList.Count)
        {
            // Get the spell data at the given index
            SaveDice.SpellData spellData = spellList[index];

            // Instantiate the dice prefabs based on the saved data
            for (int i = 0; i < spellData.d4; i++)
            {
                buttonSpawns.SpawnD4();
            }

            for (int i = 0; i < spellData.d6; i++)
            {
                buttonSpawns.SpawnD6();
            }

            for (int i = 0; i < spellData.d8; i++)
            {
                buttonSpawns.SpawnD8();
            }

            for (int i = 0; i < spellData.d10; i++)
            {
                buttonSpawns.SpawnD10();
            }

            for (int i = 0; i < spellData.d12; i++)
            {
                buttonSpawns.SpawndD12();
            }

            for (int i = 0; i < spellData.d20; i++)
            {
                buttonSpawns.SpawnD20();
            }

            for (int i = 0; i < spellData.d100; i++)
            {
                buttonSpawns.SpawnD100();
            }
        }
    }
}

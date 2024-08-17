using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDice : MonoBehaviour
{
    private SpellData spellData;
    private string path = "";

    public string spellName;
    public ButtonSpawns buttonSpawns;
    SpawnSavedDice spawnSavedDice;

    void Start()
    {
        buttonSpawns = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
        SetPaths();
        spawnSavedDice = GameObject.FindWithTag("BigGameController").GetComponent<SpawnSavedDice>();
    }

    public void CreateSpellData()
    {
        spellName = buttonSpawns.spellText;
        spellData = new SpellData(spellName, buttonSpawns.d4, buttonSpawns.d6, buttonSpawns.d8, buttonSpawns.d10, buttonSpawns.d12, buttonSpawns.d20, buttonSpawns.d100);
    }

    public void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SpellData.json";
    }

    public void AddSpellData()
    {
        CreateSpellData();

        if (!string.IsNullOrEmpty(spellName))
        {
            // Load existing spells
            List<SpellData> spellList = LoadSpellData();

            // Check if spell already exists
            if (!SpellExistsInData(spellList, spellName))
            {
                // Add the new spell to the list
                spellList.Add(spellData);

                // Save the updated spell list back to the file
                SaveSpellData(spellList);

                Debug.Log("New spell added.");
            }
            else
            {
                Debug.Log("Spell already exists in SpellData.json. Skipping addition.");
            }
        }

        //update the button names and order
        spawnSavedDice.ChangeButtonName();


    }

    public List<SpellData> LoadSpellData()
    {
        List<SpellData> spellList = new List<SpellData>();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            if (!string.IsNullOrEmpty(json))
            {
                // Deserialize the JSON into a list of SpellData objects
                spellList = JsonUtility.FromJson<SpellDataListWrapper>(json).spellDataArray;
            }
        }

        return spellList;
    }

    public void SaveSpellData(List<SpellData> spellList)
    {
        // Wrap the spell list in a wrapper object before saving
        SpellDataListWrapper wrapper = new SpellDataListWrapper();
        wrapper.spellDataArray = spellList;

        // Convert the list back to JSON format and save it
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);
    }

    public bool SpellExistsInData(List<SpellData> spellList, string spellName)
    {
        foreach (SpellData data in spellList)
        {
            if (data.spellName == spellName)
            {
                return true;
            }
        }
        return false;
    }
    public void DeleteSpellData(int index)
    {
        // Load existing spells
        List<SpellData> spellList = LoadSpellData();

        // Check if the index is within the range of the spell list
        if (index >= 0 && index < spellList.Count)
        {
            // Remove the spell at the given index
            spellList.RemoveAt(index);

            // Save the updated spell list back to the file
            SaveSpellData(spellList);

            Debug.Log("Spell deleted at index: " + index);
        }
        else
        {
            Debug.Log("Invalid index. No spell deleted.");
        }

        //update the button names and order
        spawnSavedDice.ChangeButtonName();
    }

    // Class to wrap the list of SpellData objects for JSON serialization. Can be made into a new script but kept here for convenience.
    [System.Serializable]
    public class SpellData
    {
        public string spellName;
        public int d4, d6, d8, d10, d12, d20, d100;

        public SpellData(string spellName, int d4, int d6, int d8, int d10, int d12, int d20, int d100)
        {
            this.spellName = spellName;
            this.d4 = d4;
            this.d6 = d6;
            this.d8 = d8;
            this.d10 = d10;
            this.d12 = d12;
            this.d20 = d20;
            this.d100 = d100;
        }
    }

    [System.Serializable]
    public class SpellDataListWrapper
    {
        public List<SpellData> spellDataArray;
    }

}







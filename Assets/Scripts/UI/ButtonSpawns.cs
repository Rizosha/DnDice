using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ButtonSpawns : MonoBehaviour
{ 
   [Header("Prefabs and SpawnLocation",order = 1)]
   public GameObject spawnLocation;
   public GameObject d4Prefab, d6Prefab, d8Prefab, d10Prefab, d12Prefab, d00Prefab, d20Prefab;
   
   [Header("Dice lists and how many",order = 2)]
   public int indexHowMany;
   public int d4, d6, d8, d10, d12, d20, d100;
   [SerializeField] public List<GameObject> _currentDice = new List<GameObject>();
   public Rigidbody[] currentDiceList;

   [Header("SaveMenu",order = 3)]
   public GameObject saveMenu;
   public GameObject saveButton;
   public string spellText;
   
   
   private void Update()
   {
       // sets a list of rigid bodies so I can use them in my launcher
       currentDiceList = new Rigidbody[_currentDice.Count];
       for (int i = 0; i < _currentDice.Count; ++i)
       {
           // get GameObject at index `i`
           GameObject dice = _currentDice[i];
           // set rigidbody at index `i`
           currentDiceList[i] = dice.GetComponent<Rigidbody>();
       }
   }
   // Save an int of the amount of dice you have in player prefs
   // This isn't fully implemented but it is capable of actually saving information
   void SaveDice(string buttonName, int diceSides, int numberOfDiceTypes)
   { 
       string key = buttonName + '_' + diceSides;
       PlayerPrefs.SetInt(key,numberOfDiceTypes);
   }
   
   //Calls the save on a button press
   public void ActuallySave()
   {
       SaveDice(spellText, 5,5);
   }

   //Is capable of loading the int, but i have no use for it just yet
   int LoadDice(string buttonName, int diceSides)
   {
      string key = buttonName + '_' + diceSides;
      return PlayerPrefs.GetInt(key);
   }

   /// <summary>
   /// The functions of spawning a dice through a button press. They essentially load a prefab and a + 1 value to track how many are currently spawned
   /// </summary>
   public void SpawnD4()
   { 
       d4 += 1;
      indexHowMany += 1;
      GameObject d4Arr = Instantiate(d4Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d4Arr);
   }

   public void SpawnD6()
   {
       d6 += 1;
      indexHowMany += 1;
      GameObject d6Arr = Instantiate(d6Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d6Arr);
   }

   public void SpawnD8()
   {
       d8 += 1;
      indexHowMany += 1;
      GameObject d8Arr = Instantiate(d8Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d8Arr);
   }

   public void SpawnD10()
   {
       d10 += 1;
      indexHowMany += 1;
      GameObject d10Arr = Instantiate(d10Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d10Arr);
   }

   public void SpawndD12()
   {
       d12 += 1;
      indexHowMany += 1;
      GameObject d12Arr = Instantiate(d12Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d12Arr);
   }

   public void SpawnD100()
   { 
      d100 += 1;
      indexHowMany += 1;
      GameObject d100Arr = Instantiate(d00Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d100Arr);
   }

   public void SpawnD20()
   {
      d20 += 1;
      indexHowMany += 1;
      GameObject d20Arr = Instantiate(d20Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d20Arr);
   }

   // Destroys the dice off the board and clears all the relevant arrays
   public void ClearDice()
   {
       for (int i = 0; i < _currentDice.Count; i++)
       {
           _currentDice[i].SendMessage("DestroyDice");
       }
       
       _currentDice.Clear();
       indexHowMany = 0;
       d4 = 0;
       d6 = 0;
       d8 = 0;
       d10 = 0;
       d12 = 0;
       d20 = 0;
       d100 = 0;
   }

   // open and closes the save menu
   public void OpenSaveMenu()
   {
       saveButton.SetActive(false);
       saveMenu.SetActive(true);
   }

   public void CloseSaveMenu()
   {
       saveMenu.SetActive(false);
       saveButton.SetActive(true);
   }

 
   
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawns : MonoBehaviour
{
   public GameObject spawnLocation;
   public GameObject d4Prefab, d6Prefab, d8Prefab, d10Prefab, d12Prefab, d00Prefab, d20Prefab;
   public GameObject[] currentDiceList;
   public int indexHowMany;
   public int d4, d6, d8, d10, d12, d20, d100;
   [SerializeField] public List<GameObject> _currentDice = new List<GameObject>();

   private void Update()
   {
      
   }

   void SaveDice(string buttonName, int diceSides, int numberOfDiceTypes)
   {
      string key = buttonName + '_' + diceSides;
      PlayerPrefs.SetInt(key,numberOfDiceTypes);
   }

   int LoadDice(string buttonName, int diceSides)
   {
      string key = buttonName + '_' + diceSides;
      return PlayerPrefs.GetInt(key);
   }

   public void SpawnD4()
   {
     // Instantiate(d4Prefab, spawnLocation.transform.position, quaternion.identity);
      d4 += 1;
      indexHowMany += 1;
      //Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
      GameObject d4Arr = Instantiate(d4Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d4Arr);
   }

   public void SpawnD6()
   {
     // Instantiate(d6Prefab, spawnLocation.transform.position, quaternion.identity);
      d6 += 1;
      indexHowMany += 1;
     // Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
      GameObject d6Arr = Instantiate(d6Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d6Arr);
   }

   public void SpawnD8()
   {
      //Instantiate(d8Prefab,spawnLocation.transform.position,quaternion.identity);
      d8 += 1;
      indexHowMany += 1;
     // Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
      GameObject d8Arr = Instantiate(d8Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d8Arr);
   }

   public void SpawnD10()
   {
      //Instantiate(d10Prefab, spawnLocation.transform.position, quaternion.identity);
      d10 += 1;
      indexHowMany += 1;
     // Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
      GameObject d10Arr = Instantiate(d10Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d10Arr);
   }

   public void SpawndD12()
   {
      //Instantiate(d12Prefab, spawnLocation.transform.position, quaternion.identity);
      d12 += 1;
      indexHowMany += 1;
     // Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
      GameObject d12Arr = Instantiate(d12Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d12Arr);
   }

   public void SpawnD100()
   {
      //Instantiate(d00Prefab, spawnLocation.transform.position, quaternion.identity);
      d100 += 1;
      indexHowMany += 1;
     // Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
      GameObject d100Arr = Instantiate(d00Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d100Arr);
   }

   public void SpawnD20()
   {
      //Instantiate(d20Prefab, spawnLocation.transform.position, quaternion.identity);
      d20 += 1;
      indexHowMany += 1;
     // Array.Resize(ref currentDiceList,currentDiceList.Length + 1);
      GameObject d20Arr = Instantiate(d20Prefab, spawnLocation.transform.position, quaternion.identity);
      _currentDice.Add(d20Arr);
   }

   public void ClearDice()
   {
       for (int i = 0; i < _currentDice.Count; i++)
       {
           _currentDice[i].SendMessage("DestroyDice");
          
       }
       _currentDice.Clear();
       //Array.Clear(_currentDice,indexHowMany,_currentDice.Count);
       //List<CurrentDice>.c
   }
   
   
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawns : MonoBehaviour
{
   public GameObject spawnLocation;
   public GameObject d4Prefab, d6Prefab, d8Prefab, d10Prefab, d12Prefab, d00Prefab, d20Prefab;
   
   

   public void SpawnD4()
   {
      Instantiate(d4Prefab, spawnLocation.transform.position, quaternion.identity);
   }

   public void SpawnD6()
   {
      Instantiate(d6Prefab, spawnLocation.transform.position, quaternion.identity);
   }

   public void SpawnD8()
   {
      Instantiate(d8Prefab,spawnLocation.transform.position,quaternion.identity);
   }

   public void SpawnD10()
   {
      Instantiate(d10Prefab, spawnLocation.transform.position, quaternion.identity);
   }

   public void SpawndD12()
   {
      Instantiate(d12Prefab, spawnLocation.transform.position, quaternion.identity);
   }

   public void SpawnD100()
   {
      Instantiate(d00Prefab, spawnLocation.transform.position, quaternion.identity);
   }

   public void SpawnD20()
   {
      Instantiate(d20Prefab, spawnLocation.transform.position, quaternion.identity);
   }
   
   
}

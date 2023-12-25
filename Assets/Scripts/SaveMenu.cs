using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private SpellData spellData;

    private string path = "";
    private string persistentPath = "";

    private int tutNpcIndex;
    private int loreIndex;

    public bool tutComplete = false;
    public GameObject player;
    GameObject tutSpawnLocation;
   
    //private GameObject playerV;
    [SerializeField]
    private GameObject tutLocationV;
    private CharacterController characterController;
    
    public string spellName;
    public int d4;
    public int d6;
    public int d8;
    public int d10;
    public int d12;
    public int d20;
    public int d100;
    public int modifier;
    public bool all;

    public ButtonSpawns buttonSpawns;
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        buttonSpawns = GameObject.FindWithTag("DiceSpawner").GetComponent<ButtonSpawns>();
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the sceneLoaded event
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
            LoadData();
            
        
    }
    
    
    public void CreateSpellData()
    {
        spellData = new SpellData(spellName, d4,d6,d8,d10,d12,d20,d100, modifier,all);
    }
    
    public void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SpellData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SpellData.json";
    }
    
    public void SaveData()
    {
        string savePath = path;
        string json = JsonUtility.ToJson(spellData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write((json));
    }
    
    public void LoadData()
    {
        if(File.Exists(Application.dataPath + Path.AltDirectorySeparatorChar + "SpellData.json")) {
            using StreamReader reader = new StreamReader(path);
            string json = reader.ReadToEnd();

            SpellData data = JsonUtility.FromJson<SpellData>(json);
            Debug.Log("Loaded Tutorial Data: " + data);

            /*tutComplete = data.tutComplete;
            tutNpcIndex = data.tutNpcIndex;*/
        }
    }
    
    
}

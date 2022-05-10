using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HalfDisplay : MonoBehaviour
{
    public DiceManager diceNumber;

    public DiceDisplay disp;

    public TextMeshProUGUI roll;
    public int half;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        disp = GameObject.FindWithTag("Display").GetComponent<DiceDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
        half = disp.allDiceOutput / 2;
        roll.text = half.ToString();
    }
}

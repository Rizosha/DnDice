using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HalfDisplay : MonoBehaviour
{
    public DiceManager diceNumber;

    public TextMeshProUGUI roll;
    public int half;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        diceNumber = GameObject.FindWithTag("D6").GetComponent<DiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        half = diceNumber.diceOutput / 2;
        roll.text = half.ToString();
    }
}

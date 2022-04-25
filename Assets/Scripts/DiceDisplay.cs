using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceDisplay : MonoBehaviour
{

    public DiceManager diceNumber;

    public TextMeshProUGUI roll;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        diceNumber = GameObject.FindWithTag("D6").GetComponent<DiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
       roll.text = diceNumber.diceOutput.ToString();
    }
}

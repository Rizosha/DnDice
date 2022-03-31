using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceDisplay : MonoBehaviour
{

    public D6Manager diceNumber;

    public TextMeshProUGUI roll;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        diceNumber = GameObject.FindWithTag("D6").GetComponent<D6Manager>();
    }

    // Update is called once per frame
    void Update()
    {
       roll.text = diceNumber.diceOutput.ToString();
    }
}

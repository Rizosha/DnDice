using UnityEngine;
using TMPro;

public class HalfDisplay : MonoBehaviour
{
 
    /// <summary>
    /// Displays half of the dice rolled by halving dice output
    /// </summary>
    
    public DiceDisplay disp;
    public TextMeshProUGUI roll;
    public int half;
 
    void Start()
    {
        disp = GameObject.FindWithTag("Display").GetComponent<DiceDisplay>();
    }

    void Update()
    {
        half = disp.allDiceOutput / 2;
        roll.text = half.ToString();
    }
}

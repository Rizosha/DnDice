using System.Linq;
using UnityEngine;
public class DiceManager : MonoBehaviour
{
    [Header("Sides Arrays",order = 1)]
    public Transform[] sides;
    public float[] sidesY;
    
    [Header("Dice Outputs",order = 2)]
    public float topValueY;
    public int diceOutput;
    public int modifier;
    public float diceVel;
    //change to true when thrown
    public bool canDisplay = true;
    public bool hasStopped;
    public bool allMod;
    
    [Header("Script Grabbing",order = 1)]
    public Modifier mod;
    public ModifyAll modAll;
   
    private void Start()
    {
        mod = GameObject.FindWithTag("Modifier").GetComponent<Modifier>();
        modAll = GameObject.FindWithTag("Toggle1").GetComponent<ModifyAll>();
    }

    void Update()
    {
        // shows the velocity of the dice in editor
        diceVel = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        
        // if the dice velocity is 0, output the dice number
        if (canDisplay && diceVel == 0)
        {
            DiceUpdate();
            hasStopped = true;
            canDisplay = false;
        }
        else
        {
            diceOutput = 0;
            hasStopped = false;
        }
    }

    private void DiceUpdate()
    {
        // the int modifier
        modifier = mod.modifier;
        //toggle bool
        allMod = modAll.all;
        
        // Store the Y values 
        for (int i = 0; i < sides.Length; i++)
        {
            sidesY[i] = sides[i].transform.position.y;
            if( i == sides.Length)
            {
                i = 0;
            }
        }
        //output the max value from the array
        topValueY = sidesY.Max();
        
        //adds a modifier to the dice output if selected
        if (allMod)
        {
            diceOutput = sidesY.ToList().IndexOf(topValueY) + 1 + modifier;
        }
        else
        {
            diceOutput = sidesY.ToList().IndexOf(topValueY) + 1;
        }
       
        //times output by 10 to achieve a D100
        if (gameObject.CompareTag("D100"))
        {
            diceOutput = diceOutput * 10;
        }
    }
    
    void DestroyDice()
    {
        Destroy(gameObject);
    }
}

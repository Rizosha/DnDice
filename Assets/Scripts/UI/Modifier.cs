using UnityEngine;
using TMPro;
public class Modifier : MonoBehaviour
{
    /// <summary>
    /// converts text from modifier input to storable int
    /// </summary>
    
    public int modifier;
    public TMP_InputField field;
    
    private void Update()
    {
        ModToInt();
    }

    public void ModToInt()
    {
        modifier = int.Parse(field.text);
    }
}

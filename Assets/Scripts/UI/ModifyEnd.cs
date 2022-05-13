using UnityEngine;
using Toggle = UnityEngine.UI.Toggle;

public class ModifyEnd : MonoBehaviour
{
    /// <summary>
    ///  Checks if the toggle is activated 
    /// </summary>
    
    private GameObject toggle2;
    public bool end;
    
    private void Start()
    {
        toggle2 = GameObject.FindWithTag("Toggle2");
        toggle2.GetComponent<Toggle>().isOn = false;
    }

    private void Update()
    {
        end = toggle2.GetComponent<Toggle>().isOn;
    }
}

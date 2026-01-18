using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAnim : MonoBehaviour
{

    public void MoveDown()
    {
        //send message to parent to move down
        gameObject.transform.parent.gameObject.SendMessage("MoveDown");

    }

    public void SetDownOn()
    {
        gameObject.transform.parent.gameObject.SendMessage("SetDownOn");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    private Animator menuAnim;

    private void Start()
    {
        menuAnim = gameObject.GetComponent<Animator>();
    }

    public void OpenMenu()
    {
        bool open = menuAnim.GetBool("MenuOpen");
        if (!open)
        {
            menuAnim.SetBool("MenuOpen", true);
        }
        else
        {
            menuAnim.SetBool("MenuOpen", false);
        }
        
    }
    
}

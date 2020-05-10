using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour
{
    public bool ButtonActive = false;
    public void ButtonUp()
    {
        ButtonActive = false;
    }
    public void ButtonDown()
    {
        ButtonActive = true;
        Debug.Log("kkkk");
    }
}

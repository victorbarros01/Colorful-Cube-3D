using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject window;
    public GameObject otherWindow;

    public void CloseWindow()
    {
        window.SetActive(true);
        if(otherWindow != null)otherWindow.SetActive(false);
    }
    

}

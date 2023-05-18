using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text txtCount;
    public GameObject obj;
    public int time;

    public void Start()
    {
        obj.SetActive(false); 
        InvokeRepeating("Count", 0f, 1f);
        if(txtCount != null)
        {
            txtCount.text = time.ToString();
        }
    }

    void Count()
    {
        time--;
        if(txtCount != null)
        {
            txtCount.text = time.ToString();
        }
        if(time < 0)
        {
            obj.SetActive(true);
            CancelInvoke("Count");
        }
    }

}

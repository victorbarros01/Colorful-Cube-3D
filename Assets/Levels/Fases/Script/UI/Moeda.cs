using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moeda : MonoBehaviour
{   
    public TextMeshProUGUI valorMoeda;
    public void FixedUpdate()
    {
        valorMoeda.text = PlayerPrefs.GetInt("Moedas").ToString();
    }
}

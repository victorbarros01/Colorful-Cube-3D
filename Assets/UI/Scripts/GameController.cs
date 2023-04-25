using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public TextMeshProUGUI touchContinue;
    public GameObject[] levels;
    public void SkipToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void SkipToFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Update()
    {
        touchContinue.enabled = Mathf.PingPong(Time.time, 0.5f) > 0.25f;
    }

    public void AtiveLevel()
    {
        for(int i = 0; i < levels.Length; i++)
        {
          levels[i].SetActive(true);  
        }
    }



}

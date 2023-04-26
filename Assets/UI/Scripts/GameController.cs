using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    [Header("GameController")]
    public GameController gameController;
    [Header("Pré-Lobby")]
    public TextMeshProUGUI touchContinue;
    [Header("Lobby")]
    public GameObject optsButton;
    public GameObject[] levels;
    public void SkipToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1f;        
    }
    public void SkipToFase1()
    {
        SceneManager.LoadScene("Fase1");
        Time.timeScale = 1f;
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

    public void Options()
    {
     optsButton.SetActive(true);
     Time.timeScale = 0f;
    }

    public void ExitOptions()
    {
     optsButton.SetActive(false);
     Time.timeScale = 1f;
    }



}

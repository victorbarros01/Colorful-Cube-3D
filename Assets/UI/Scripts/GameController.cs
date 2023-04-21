using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public TextMeshProUGUI touchContinue;
    public void SkipToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Update()
    {
        touchContinue.enabled = Mathf.PingPong(Time.time, 0.5f) > 0.25f;

        
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{       
    [Header("Pré-Lobby")]
    public AudioSource music;
    public GameObject preLobby;
    public GameObject lobby;
    public TextMeshProUGUI touchContinue;
    [Header("Lobby")]
    public GameObject optsButton;
    public GameObject[] levels;
    
    public void CarregarCena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void Update()
    {
        touchContinue.enabled = Mathf.PingPong(Time.time, 0.5f) > 0.25f;
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

    public void ButtonPreLobby()
    {
        lobby.SetActive(true);
        preLobby.SetActive(false);
        music.volume = 0.14f;
    }

    public void StarsLobby(string Stars)
    {
        int stars = PlayerPrefs.GetInt(Stars);
        Debug.Log(PlayerPrefs.GetInt(Stars));
    }



}

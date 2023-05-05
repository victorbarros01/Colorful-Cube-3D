using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PainelFases : MonoBehaviour
{
    public TMP_Text stageName;
    public Image[] lobbyStars = new Image[3];
    public Color preenchida;
    public Color nPreenchida;
    public string sceneName;
    public static PainelFases instance;

    void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            gameObject.SetActive(false);
        }else
        if(instance != null){
            Destroy(this);
        }

    }
    public void OpenWindow(string nameFase, int qntStars, string nameScene)
    {
        stageName.text = nameFase;
        for(int i = 0; i < lobbyStars.Length; i++)
        {
            if(i < qntStars)
            {
                lobbyStars[i].color = preenchida;
            }else
            {
                lobbyStars[i].color = nPreenchida;
            }
        }
        sceneName = nameScene;
        gameObject.SetActive(true);

    }

    public void CarregarCena()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}

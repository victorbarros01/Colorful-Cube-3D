using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class ScriptCanvas : MonoBehaviour
{
    [Header("Continue")]
    public Material[] armadilhasMaterials;
    public GameObject[] armadilhas;
    public Text countdown;
    bool isContinued = false;
    public int countdownInt = 10;
    public GameObject continueUI;

    [Header("Win&Lose")]
    int coinValue;
    public string nameLevel;
    public GameObject win;
    public GameObject lose;
    public int stars = 3;

    [Header("MenuPause")]
    public GameObject paused;
    public bool isPaused = false;   
    [Header("Slider")]
    public int valorTotalSlider;
    public Slider contaPassos;
    public Sprite EstrelaVazia;
    public Image[] starSlider = new Image[3];
    public int[] maxPassos = new int[3];
    [Header("Instancia")]
    public static ScriptCanvas Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        if(Instance != null){
            Destroy(this);
        }
    }

    public void Start()
    {
        contaPassos.value = valorTotalSlider;
    }

    /*public void Update()
    {
        if(isContinued == true)
        {    
            for(int i = 0; 0 < 10; i++)
            {
                countdownInt--;
                countdown.text = countdownInt.ToString();
            }

            if(countdownInt <= 0)
            {
                DeathPlayer.deathPlayer.Again();
            }
        }
    } */

    public void SkipScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        Time.timeScale = 1f;
    }

    public void Paused()
    {
        isPaused = true;
        paused.SetActive(true);
        Invoke(nameof(TimeScale), 10f);        
        
    }

    public void NotPaused()
    {
        isPaused = false;
        paused.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void TimeScale()
    {
        Time.timeScale = 0f;
    }

    public void UpdateStar(int passosAtuais)
    {
        for(int i = 0; i < starSlider.Length; i++)
        {
            if(maxPassos[i] > passosAtuais)
            {
                starSlider[i].overrideSprite = EstrelaVazia;
                stars--;
            }else
            {
                starSlider[i].overrideSprite = null;
            }
        }
    }

    public void LevelConcluido()
    {
        if(PlayerPrefs.HasKey(nameLevel))
        {
            if(PlayerPrefs.GetInt(nameLevel)< stars)
            {
                PlayerPrefs.SetInt(nameLevel, stars);
                PlayerPrefs.Save();
            }  
        }else
        {
                PlayerPrefs.SetInt(nameLevel, stars);
                PlayerPrefs.Save();
        }
        coinValue+=100;
        PlayerPrefs.SetInt("Moedas", coinValue);
        win.SetActive(true);
        Invoke(nameof(TimeScale), 5f);
    }

    public void Continue()
    {
        continueUI.SetActive(true);
        isContinued = true;
    }

    public void BuyContinue()
    {
        PlayerPrefs.SetInt("Moedas", coinValue-=50);
        continueUI.SetActive(false);
        Time.timeScale = 1f;
        for(int i = 0; i < armadilhas.Length; i++)
        {
            armadilhas[i].GetComponent<DeathPlayer>().enabled = false;
            armadilhasMaterials[i].color = Color.white;
        }
        Invoke(nameof(ReturnNormal), 4f);
    }

    public void ReturnNormal()
    {
       for(int i = 0; i < armadilhas.Length; i++)
        {
            armadilhas[i].GetComponent<DeathPlayer>().enabled = true;
            armadilhasMaterials[i].color = new Color(0.6431373f,0.6431373f,0.6431373f);
        } 
    }




}

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
    public int countdownInt = 10;
    public GameObject continueUI;
    public int coinValue
    {
        get
        {   
            return PlayerPrefs.GetInt("Moedas", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Moedas", value);
        }
    }
    [Header("Win&Lose")]
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
    public string level;
    public bool[] unlockLevel = new bool[4];
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

        for(int i = 0; i < unlockLevel.Length; i++)
        {
            unlockLevel[i] = false;
        }
    
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
        switch(level)
        {
            case "Fase1":
                unlockLevel[0] = true;
                break;
            
            case "Fase2":
                unlockLevel[1] = true;
                break;
            
            case "Fase3":
                unlockLevel[2] = true;
                break;
            
            case "Fase4":
                unlockLevel[3] = true;
                break;



        }
    }

    public void Continue()
    {
        continueUI.SetActive(true);
    }

    public void BuyContinue()
    {
        
        if(PlayerPrefs.GetInt("Moedas") >= 50)
        {
        coinValue-=50;
        PlayerPrefs.SetInt("Moedas", coinValue);      
        Destroy(continueUI) ;
        Time.timeScale = 1f;
        for(int i = 0; i < armadilhas.Length; i++)
        {
            armadilhas[i].SetActive(false);
        }
        }
    }

}

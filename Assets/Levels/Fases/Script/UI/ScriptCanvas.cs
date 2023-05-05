using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class ScriptCanvas : MonoBehaviour
{
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
        win.SetActive(true);
        Invoke(nameof(TimeScale), 5f);
    }



}

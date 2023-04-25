using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class ScriptCanvas : MonoBehaviour
{
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

    public void Again()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1f;

    }

    public void MenuReturn()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void SkipLevel()
    {
        SceneManager.LoadScene("Fase1");
        Time.timeScale = 1f;

    }
    public void Paused()
    {
        isPaused = true;
        paused.SetActive(true);
        Invoke(nameof(TimeScale), 5f);        
        
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
            }else
            {
                starSlider[i].overrideSprite = null;
            }
        }
    }



}

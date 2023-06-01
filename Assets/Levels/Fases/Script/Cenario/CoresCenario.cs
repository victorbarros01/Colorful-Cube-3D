using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CoresCenario : MonoBehaviour
{
    public Lados Cor;
    public UnityEvent Event;
    public Image image;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<LadosCores>(out LadosCores ladosCores)  && ladosCores.cores == Cor)
        {
            Event?.Invoke();
            Debug.Log(ScriptCanvas.Instance.unlockLevel);        
        }
    }

    public void Green()
    {
        image.color = Color.green;
        Invoke(nameof(DisableComponent), 1f);
    }

    public void Blue()
    {
        Color blueColor = new Color(0f, 0.99215686f, 1f, 1f);
        image.color = blueColor;
        Invoke(nameof(DisableComponent), 1f);
    }

    public void Orange()
    {
        Color orangeColor = new Color(1f, 0.5f, 0f, 1f);
        image.color = orangeColor;
        Invoke(nameof(DisableComponent), 1f);
    }

    public void Yellow()
    {
        image.color = Color.yellow;
        Invoke(nameof(DisableComponent), 1f);
    }

    public void DisableComponent()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;
    }

    public void Purple()
    {
        Color purpleColor = new Color(0.5647059f, 0.13725491f, 1f, 1f);
        image.color = purpleColor;
        Invoke(nameof(DisableComponent), 1f);
    }
    
}

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
            
        }
    }

    public void Green()
    {
        image.color = Color.green;
    }

    public void Blue()
    {
        Color blueColor = new Color(0f, 0.99215686f, 1f, 1f);
        image.color = blueColor;
    }

    public void Orange()
    {
        Color orangeColor = new Color(1f, 0.5f, 0f, 1f);
        image.color = orangeColor;
    }

    public void Yellow()
    {
        image.color = Color.yellow;
    }

    public void Purple()
    {
        Color purpleColor = new Color(0.5647059f, 0.13725491f, 1f, 1f);
        image.color = purpleColor;
    }
    
}

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
        image.color = Color.blue;
    }

    
}

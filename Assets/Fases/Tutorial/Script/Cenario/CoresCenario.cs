using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CoresCenario : MonoBehaviour
{
    public Lados Cor;
    public UnityEvent Event;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<LadosCores>(out LadosCores ladosCores)  && ladosCores.cores == Cor)
        {
            Event?.Invoke();
        }
    }

    
}

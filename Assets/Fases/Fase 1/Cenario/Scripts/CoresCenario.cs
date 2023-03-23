using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CoresCenario : MonoBehaviour
{
    public Lados Cor;
    public UnityEvent Event;
    void Update() {


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<LadosCores>(out LadosCores ladosCores)  && ladosCores.cores == Cor)
        {
            //Barrer.GetComponent<Mov_Barrer>().enabled = true;

            Event?.Invoke();
        }

    }

    public void skipLevel()
    {
        SceneManager.LoadScene("Fase 1");
    }



}

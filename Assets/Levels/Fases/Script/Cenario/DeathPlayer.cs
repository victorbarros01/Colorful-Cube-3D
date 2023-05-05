using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    public GameObject TenteNovamente;
    public AudioSource som;
    public AudioSource player;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            TenteNovamente.SetActive(true);
            player.Play();
            Time.timeScale = 0f;
        }
    }

    public void Som()
    {
        som.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animation animation;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)&& !animation.isPlaying)
        {
            animation.Play("Bloco1");
            Debug.Log("A");
        }
        if(Input.GetKeyDown(KeyCode.S)&& !animation.isPlaying)
        {
            animation.Play("Bloco2");
            Debug.Log("A");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animation animation;

    public void PressAnimation()
    {
       animation.Play("Bloco2"); 
    }
}

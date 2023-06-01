using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public bool openMenu = false;
    void Awake()
    {
        if(manager == null)
        {
            manager = this;
        }else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}

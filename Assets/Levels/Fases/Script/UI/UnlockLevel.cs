using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public Image level;

    void Start()
    {
        for(int i = 0; i < 4; i++){
            switch(ScriptCanvas.Instance.unlockLevel[i])
                {
                    case true:
                    level.color = Color.white;
                    break;
                }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public string levelName;
    public string sceneLevelName;

    public void OpenWindowLevel()
    {
        PainelFases.instance.OpenWindow(levelName, PlayerPrefs.GetInt(levelName, 0),sceneLevelName);
    }
}

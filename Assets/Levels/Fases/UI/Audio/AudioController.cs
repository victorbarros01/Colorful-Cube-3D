using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;
    public Toggle[] toggles = new Toggle[2];//0 = Music , 1 = SFX
    public Sprite[] noAudioElements = new Sprite[2]; //0 = Music , 1 = SFX
    public Image[] audioElements = new Image[2]; //0 = Music , 1 = SFX    
    public void Start()
    {
        float _sfx = PlayerPrefs.GetFloat("VolumeSfx");
        float _music = PlayerPrefs.GetFloat("VolumeMusic");
        if(_music == 0f)
        {
            SwitchMusic(true);
            toggles[0].isOn = true;
        }else
        {
            SwitchMusic(false);
            toggles[0].isOn = false;
        }
        if(_sfx == 0f)
        {
            SwitchSFX(true);
            toggles[1].isOn = true;
        }else
        {
            SwitchSFX(false);
            toggles[1].isOn = false;
        }
    }
    public void SwitchMusic(bool musicOn)
    {
        if(musicOn)
        {
            mixer.SetFloat("VolumeMusic", 0f);
            audioElements[0].overrideSprite = null;
            PlayerPrefs.SetFloat("VolumeMusic", 0f);
            PlayerPrefs.Save();

        }else{
            mixer.SetFloat("VolumeMusic", -80f);
            audioElements[0].overrideSprite = noAudioElements[0];
            PlayerPrefs.SetFloat("VolumeMusic", -80f);
            PlayerPrefs.Save();
        }
    }

    public void SwitchSFX(bool sfxOn)
    {
        if(sfxOn)
        {
            mixer.SetFloat("VolumeSfx", 0f);
            audioElements[1].overrideSprite = null;
            PlayerPrefs.SetFloat("VolumeSfx", 0f);
            PlayerPrefs.Save();
        }else{
            mixer.SetFloat("VolumeSfx", -80f);
            audioElements[1].overrideSprite = noAudioElements[1];
            PlayerPrefs.SetFloat("VolumeSfx", -80f);
            PlayerPrefs.Save();
        }
    }
}

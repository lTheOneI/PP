using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class SettingMenu : MonoBehaviour
{
    //[SerializeField] AudioMixer 
    [SerializeField] Slider volumeMusicSlider;
    [SerializeField] Slider volumeSoundSlider;

    UIManage uIManageScript;

    void Start()
    {
        uIManageScript = FindObjectOfType<UIManage>();
        if (!PlayerPrefs.HasKey("musicVolume"))
            {
            PlayerPrefs.SetFloat("musicVolume", volumeMusicSlider.value =1);
            }
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soudnVolume", volumeSoundSlider.value = 1);
        }


    }
    void OnEnable()

    {
        volumeMusicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        volumeSoundSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeMusicSlider.value);
        PlayerPrefs.SetFloat("soundVolume", volumeSoundSlider.value);
        uIManageScript.soundSource.volume = volumeSoundSlider.value;
        uIManageScript.musicSource.volume = volumeMusicSlider.value;
        Debug.Log("Music Volume: " + PlayerPrefs.GetFloat("musicVolume"));
        Debug.Log("Sound Volume: " + PlayerPrefs.GetFloat("soundVolume"));
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    UIManage uiManageScript;

    [Header("Buttons")]
    [SerializeField] Button replayBtn;
    [SerializeField] Button contactBtn;
    [SerializeField] Button soundBtn;
    [SerializeField] Button musicBtn;

    //[SerializeField] AudioMixer 
    [Header("Volume Slider")]
    [SerializeField] Slider volumeMusicSlider;
    [SerializeField] Slider volumeSoundSlider;

    void Start()
    {
        uiManageScript = FindObjectOfType<UIManage>();
        if (!PlayerPrefs.HasKey("musicVolume"))
            {
            PlayerPrefs.SetFloat("musicVolume", volumeMusicSlider.value =1);
            }
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soudnVolume", volumeSoundSlider.value = 1);
        }

        replayBtn.onClick.AddListener(ReplayScene);
        contactBtn.onClick.AddListener(ContactIn4);
        soundBtn.onClick.AddListener(Sound);
        musicBtn.onClick.AddListener(Music);
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
        uiManageScript.soundSource.volume = volumeSoundSlider.value;
        uiManageScript.musicSource.volume = volumeMusicSlider.value;
        Debug.Log("Music Volume: " + PlayerPrefs.GetFloat("musicVolume"));
        Debug.Log("Sound Volume: " + PlayerPrefs.GetFloat("soundVolume"));
    }

    void ReplayScene()
    {
        uiManageScript.StartGame();
        uiManageScript.ContinueGame();
    }

    void ContactIn4()
    {
        Application.OpenURL("");
    }

    void Sound()
    {
        if(uiManageScript.soundSource.volume != 0) 
        {
            uiManageScript.soundSource.volume = 0;
        }
        else if (uiManageScript.soundSource.volume ==0 )
        {
            uiManageScript.soundSource.volume = 1;
        }
    }

    void Music()
    {
        if (uiManageScript.musicSource.volume != 0)
        {
            uiManageScript.soundSource.volume = 0;
            PlayerPrefs.SetFloat("soundVolume", volumeSoundSlider.value);
        }
        else if (uiManageScript.musicSource.volume == 0)
        {
            uiManageScript.musicSource.volume = 1; 
            PlayerPrefs.SetFloat("musicVolume", volumeMusicSlider.value);
        }
    }
}

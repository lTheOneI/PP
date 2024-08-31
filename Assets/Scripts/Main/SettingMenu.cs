using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    //[SerializeField] AudioMixer 
    [SerializeField] Slider volumeMusicSlider;
    [SerializeField] Slider volumeSoundSlider;


    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
            {
            PlayerPrefs.SetFloat("musicVolume", volumeMusicSlider.value =1);
            }
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soudnVolume", volumeSoundSlider.value =1);
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
        Debug.Log("Music Volume: " + PlayerPrefs.GetFloat("musicVolume"));
        Debug.Log("Sound Volume: " + PlayerPrefs.GetFloat("soundVolume"));
    }

}

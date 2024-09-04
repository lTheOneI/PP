using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource ButtonSource;

    [SerializeField] TMP_Text highScoreText;
    [SerializeField] Button playBtn;
    [SerializeField] Button creditBtn;
    void Start()
    {
        highScoreText.text = ( "Your HighScore: " + PlayerPrefs.GetInt("HighScore"));
        playBtn.onClick.AddListener(StartGame);
        creditBtn.onClick.AddListener(OpenPro5);
    }

    void StartGame()
    {
        ButtonSource.Play();
        SceneManager.LoadScene("Ingame");
    }

    void OpenPro5()
    {
        ButtonSource.Play();
        Application.OpenURL("https://www.facebook.com/");
    }
}

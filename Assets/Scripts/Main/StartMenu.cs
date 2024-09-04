using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("Ingame");
    }

    void OpenPro5()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
}

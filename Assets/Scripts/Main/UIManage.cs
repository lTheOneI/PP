using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] Button mainMenuBtn;

    public GameObject losePanel;
    public TMP_Text highScoreText;

    void Awake()
    {
        playBtn.onClick.AddListener(startGame);
        mainMenuBtn.onClick.AddListener(mainMenu);
        highScoreText.text = "HIGHSCORE:" + PlayerPrefs.GetInt("HighScore");
    }



    void mainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    void startGame()
    {
        SceneManager.LoadScene("Ingame");
        GameLogic.currentScore = 0;
        GameLogic.coins = 10;
    }
}

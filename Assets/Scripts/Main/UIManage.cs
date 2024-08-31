using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] Button mainMenuBtn;
    [SerializeField] Button pauseBtn;
    [SerializeField] Button continueBtn;
    [SerializeField] Button settingBtn;
    [SerializeField] Button shopBtn;

    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject settingPanel;

    public GameObject finalPanel;
    public GameObject loseText;
    public GameObject winText;

    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text finalScore;

    void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                playBtn.onClick.AddListener(StartGame);
                mainMenuBtn.onClick.AddListener(GoToMainMenu);
                pauseBtn.onClick.AddListener(PauseGame);
                continueBtn.onClick.AddListener(ContinueGame);
                shopBtn.onClick.AddListener(OpenClose_ShopPanel);
            }
        }
        //Display highScore in Start Menu
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");


    }

    private void Update()
    {
        if (GameLogic.currentScore >= PlayerPrefs.GetInt("HighScore"))
        {
            finalScore.text = "New Record: " + PlayerPrefs.GetInt("HighScore");
        }
        else if (GameLogic.currentScore < PlayerPrefs.GetInt("HighScore"))
        {
            finalScore.text = "Your Score: " + GameLogic.currentScore;
        }
        if (settingPanel.activeSelf)
        {
            PauseGame();
        }
        else if (!settingPanel.activeSelf)
        {
            ContinueGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        continueBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        pauseBtn.gameObject.SetActive(true);
        continueBtn.gameObject.SetActive(false);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    void StartGame()
    {
        SceneManager.LoadScene("Ingame");
        GameLogic.currentScore = 0;
        GameLogic.coins = 10;
    }

    void OpenClose_ShopPanel()
    {
        if (shopPanel.activeSelf==false)
        shopPanel.SetActive(true);
        else if (shopPanel.activeSelf ==true)
        {
        shopPanel.SetActive(false);
        }
    }
}
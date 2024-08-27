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

    public GameObject losePanel;
    [SerializeField] TMP_Text highScoreText;

    private void Start()
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
                settingBtn.onClick.AddListener(OpenClose_Settings);
                shopBtn.onClick.AddListener(OpenClose_ShopPanel);
            }
        }
        //Display highScore in Start Menu
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
        
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

    void OpenClose_Settings()
    {
        if (settingPanel.activeSelf == false)
        {
            Time.timeScale = 0;
            settingPanel.SetActive(true);
        }
        else if (settingPanel.activeSelf == true)
        {
            Time.timeScale = 1;
            settingPanel.SetActive(false);
        }
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
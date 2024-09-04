using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    //Buttons
    [Header("Buttons")]
    [SerializeField] Button playBtn;
    [SerializeField] Button mainMenuBtn;
    [SerializeField] Button pauseBtn;
    [SerializeField] Button continueBtn;
    [SerializeField] Button settingBtn;
    [SerializeField] Button shopBtn;

    //Objects
    [Header("Objects")]
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject cake;
    public GameObject finalPanel;
    public GameObject loseText;
    public GameObject winText;

    //AudioSources
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource soundSource;
    public AudioSource buttonSource;

    //Text to Display
    [Header("Text Fiels")]
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text finalScore;

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
                shopBtn.onClick.AddListener(OpenClose_ShopPanel);
            }
        }
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
        musicSource.Play();
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
        
    }

    public void PauseGame()
    {
        buttonSource.Play();
        musicSource.Pause();
        Debug.Log("Music Paused");
        Time.timeScale = 0;
        continueBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
    }

    public void ContinueGame()
    {
        buttonSource.Play();
        musicSource.UnPause();
        Time.timeScale = 1;
        pauseBtn.gameObject.SetActive(true);
        continueBtn.gameObject.SetActive(false);
    }

    void GoToMainMenu()
    {
        buttonSource.Play();
        SceneManager.LoadScene("Main");
    }

    public void StartGame()
    {
        buttonSource.Play();
        Destroy(cake);
        SceneManager.LoadScene("Ingame");
        GameLogic.currentScore = 0;
        GameLogic.coins = 10;
    }

    void OpenClose_ShopPanel()
    {
        buttonSource.Play();
        if (shopPanel.activeSelf==false)
        shopPanel.SetActive(true);
        else if (shopPanel.activeSelf ==true)
        {
        shopPanel.SetActive(false);
        }
    }
}
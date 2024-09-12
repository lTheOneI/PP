using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
        if (GameLogic.currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            finalScore.text = "New Record: " + PlayerPrefs.GetInt("HighScore");
        }
        else if (GameLogic.currentScore <= PlayerPrefs.GetInt("HighScore"))
        {
            finalScore.text = "Your Score: " + GameLogic.currentScore;
        }
    }

    public void PauseGame()
    {
        pauseBtn.transform.DOScale(pauseBtn.transform.localScale * 1.2f, 0.1f).OnComplete(() =>
        {
            pauseBtn.transform.DOScale(new Vector2(1, 1), 0.1f);
        }
        );
        buttonSource.Play();
        musicSource.Pause();
        Time.timeScale = 0;
        continueBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        foreach(Collider2D col in colliders)
        {
            col.enabled = false;
        }
    }

    public void ContinueGame()
    {
        continueBtn.transform.DOScale(continueBtn.transform.localScale * 1.2f, 0.1f).OnComplete(() =>
        {
            continueBtn.transform.DOScale(new Vector2(1, 1), 0.1f);
        }
        );
        buttonSource.Play();
        musicSource.UnPause();
        Time.timeScale = 1;
        pauseBtn.gameObject.SetActive(true);
        continueBtn.gameObject.SetActive(false);
        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = true;
        }
    }

    void GoToMainMenu()
    {
        mainMenuBtn.transform.DOScale(new Vector2(1.2f, 1.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
        buttonSource.Play();
        SceneManager.LoadScene("Main");
    }

    public void StartGame()
    {
        playBtn.transform.DOScale(new Vector2(1.2f, 1.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
        buttonSource.Play();
        Destroy(cake);
        SceneManager.LoadScene("Ingame");
        GameLogic.currentScore = 0;
        GameLogic.coins = 10;
    }

    void OpenClose_ShopPanel()
    {
        shopBtn.transform.DOScale(new Vector2(1.2f, 1.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
        buttonSource.Play();
        if (shopPanel.activeSelf==false)
        shopPanel.SetActive(true);
        else if (shopPanel.activeSelf ==true)
        {
        shopPanel.SetActive(false);
        }
    }

}
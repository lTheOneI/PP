using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] Button settingBtn;
    [SerializeField] GameObject settingPanel;

    public TMP_Text highScore;

    void Start()
    {
        playBtn.onClick.AddListener(startGame);
        settingBtn.onClick.AddListener(openSettingPanel);
    }

    void openSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    void startGame()
    {
        SceneManager.LoadScene("Ingame");
    }
}

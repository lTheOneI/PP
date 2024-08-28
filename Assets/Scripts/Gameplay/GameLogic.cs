using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameLogic : MonoBehaviour
{
    public static int currentScore;
    public static int coins =10;
    public static int highScore;

    [SerializeField] GameObject antPrefab;
    [SerializeField] GameObject butterflyPrefab;

    [SerializeField] GameObject screen;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text healthText;

    public GameObject cake;
    public TMP_Text coinsText;

    private int spawnWaveCount = 5;
    private int numberPerWave = 5;

    private Vector2 spawnPos;
    private int waveCount =0;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        StartCoroutine(SpawnAnts());     
    }
    void Update()
    {
        //Set new Highscore
        currentScoreText.text = "Score:" + currentScore;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
        }
        coinsText.text = coins.ToString();

        healthText.text = "Current HP: " + Cake.currentHealth;
    }

    IEnumerator SpawnAnts()
    {
        //Spawn Enemy Wave an random locations 
        for (int i = 0;i<spawnWaveCount;i++) 
        {
            for (int a = 0; a < numberPerWave; a++)
            {
                RectTransform rectTransform = screen.GetComponent<RectTransform>();
                float width = rectTransform.rect.width;
                float height = rectTransform.rect.height;
                Vector2 CenterSize = new Vector2(width / 130, height / 130);
                float angle = Random.Range(0f, 360f);
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                float distance = Random.Range(1f, 3f);
                spawnPos = Vector2.zero + direction * (CenterSize.magnitude / 2 + distance);
                Instantiate(antPrefab, spawnPos,transform.rotation);
            }
            yield return new WaitForSeconds(3f);
            waveCount++;
            if (waveCount > 4)
            {
                StartCoroutine(SpawnButterflies());
            }

        }
        yield return new WaitForSeconds(5f);
    }

    IEnumerator SpawnButterflies()
    {
        for (int i = 0; i < spawnWaveCount; i++)
        {
            for (int a = 0; a < numberPerWave; a++)
            {
                RectTransform rectTransform = screen.GetComponent<RectTransform>();
                float width = rectTransform.rect.width;
                float height = rectTransform.rect.height;
                Vector2 CenterSize = new Vector2(width / 130, height / 130);
                float angle = Random.Range(0f, 360f);
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                float distance = Random.Range(1f, 3f);
                spawnPos = Vector2.zero + direction * (CenterSize.magnitude / 2 + distance);
                Instantiate(butterflyPrefab, spawnPos, cake.transform.rotation);
            }
            yield return new WaitForSeconds(3.0f);

        }
        yield return new WaitForSeconds(5f);
    }

}

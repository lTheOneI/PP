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
    [SerializeField] GameObject beetlePrefab;
    [SerializeField] GameObject screen;

    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text healthText;

    public GameObject cake;
    public TMP_Text coinsText;

    private int spawnWaveCount = 15;
    private int numberPerWave = 4;
    public int waveCount = 0;
    private float timeBetweenWaves = 4f;

    private Vector2 spawnPos;
    private RectTransform rectTransform;
    private float width, height;
    private Vector2 screenSize;
    void Start()
    {

        //Identify the ScreenSize
        rectTransform = screen.GetComponent<RectTransform>();
        width = rectTransform.rect.width;
        height = rectTransform.rect.height;
        screenSize = new Vector2(width / 130, height / 130);

        //Get Highscore
        highScore = PlayerPrefs.GetInt("highScore", 0);

        //Startthe Game
        StartCoroutine(SpawnAnts());     
    }
    void Update()
    {
        //Set new Highscore
        currentScoreText.text = "Score: " + currentScore;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            Debug.Log("New Record: " + PlayerPrefs.GetInt("HighScore"));
        }
        coinsText.text = coins.ToString();
        healthText.text = "Current HP: " + Cake.currentHealth;

    }

    IEnumerator SpawnAnts()
    {
        for (int i = 0;i<spawnWaveCount;i++) 
        {
            for (int a = 0; a < numberPerWave; a++)
            {
                //Spawn Enemy Wave an random locations 

                float angle = Random.Range(0f, 360f);
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                float distance = Random.Range(1f, 2.5f);
                spawnPos = Vector2.zero + direction * (screenSize.magnitude / 2 + distance);
                Instantiate(antPrefab, spawnPos,transform.rotation);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
            waveCount++;
            if (waveCount > spawnWaveCount -1)
            {
                StartCoroutine(SpawnButterflies());
            }

        }
        yield return new WaitForSeconds(7f);
    }

    IEnumerator SpawnButterflies()
    {
        for (int i = 0; i < spawnWaveCount; i++)
        {
            for (int a = 0; a < numberPerWave; a++)
            {
                //Spawn Enemy Wave an random locations 

                float angle = Random.Range(0f, 360f);
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                float distance = Random.Range(1f, 3f);
                spawnPos = Vector2.zero + direction * (screenSize.magnitude / 2 + distance);
                Instantiate(butterflyPrefab, spawnPos, cake.transform.rotation);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
            waveCount++;
            if (waveCount > (2*spawnWaveCount) -1) 
            {
                StartCoroutine(SpawnBeetle());
            }
        }
        yield return new WaitForSeconds(5f);
    }

    IEnumerator SpawnBeetle()
    {
        for (int i = 0; i < spawnWaveCount; i++)
        {
            for (int a = 0; a < numberPerWave; a++)
            {
                //Spawn Enemy Wave an random locations 

                float angle = Random.Range(0f, 360f);
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                float distance = Random.Range(1f, 3f);
                spawnPos = Vector2.zero + direction * (screenSize.magnitude / 2 + distance);
                Instantiate(beetlePrefab, spawnPos, cake.transform.rotation);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        yield return new WaitForSeconds(7f);
    }
}

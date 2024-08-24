using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static int currentScore;
    public static int coins =10;

    [SerializeField] GameObject antPrefab;
    [SerializeField] GameObject butterflyPrefab;
    [SerializeField] GameObject screen;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] GameObject cake;

    public TMP_Text coinsText;
    private int spawnWaveCount = 4;
    private int count;

    private Vector3 spawnPos;
    private Vector3 direction;
    private Quaternion EnemyRotation;
    private Vector3 Var = new Vector3 (1, 1, 0);
    void Start()
    {
        direction = (cake.transform.position - antPrefab.transform.position);
        EnemyRotation = Quaternion.LookRotation(direction);
        Debug.Log(EnemyRotation);
        StartCoroutine(SpawnAnts());
        
        if (count <2) 
        {
        StartCoroutine(SpawnButterflies());
        }
    }
    private void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Ant");
        count = objects.Length;
        currentScoreText.text = "Score:" + currentScore;
        coinsText.text = "Coins:" + coins;
    }

    IEnumerator SpawnAnts()
    {
        //Spawn Enemy Wave an random locations 
        for (int i = 0;i<spawnWaveCount;i++) 
        {
            for (int a = 0; a < 5; a++)
            {
                RectTransform rectTransform = screen.GetComponent<RectTransform>();
                float width = rectTransform.rect.width;
                float height = rectTransform.rect.height;
                Vector3 CenterSize = new Vector2(width / 130, height / 130);
                float angle = Random.RandomRange(0f, 360f);
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), Mathf.Cos(angle));
                float distance = Random.Range(1f, 3f);
                spawnPos = Vector3.zero + direction * (CenterSize.magnitude / 2 + distance);
                Instantiate(antPrefab, spawnPos, EnemyRotation);
            }
            yield return new WaitForSeconds(3.0f);
        }
        yield return null;
    }

    IEnumerator SpawnButterflies()
    {
        for (int i = 0; i < spawnWaveCount; i++)
        {
            for (int a = 0; a < 5; a++)
            {
                RectTransform rectTransform = screen.GetComponent<RectTransform>();
                float width = rectTransform.rect.width;
                float height = rectTransform.rect.height;
                Vector3 CenterSize = new Vector2(width / 130, height / 130);
                float angle = Random.RandomRange(0f, 360f);
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), Mathf.Cos(angle));
                float distance = Random.Range(1f, 3f);
                spawnPos = Vector3.zero + direction * (CenterSize.magnitude / 2 + distance);
                Instantiate(butterflyPrefab, spawnPos, EnemyRotation);
            }
            yield return new WaitForSeconds(3.0f);
        }
        yield return null;
    }

    

}

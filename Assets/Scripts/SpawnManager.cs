using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    private ScoreManager scoreManager;

    float minBorderX = -52f;
    float maxBorderX = 50f;
    float minBorderZ = -23f;
    float maxBorderZ = 28f;
    Vector3 boxColliderChecker = new Vector3(2, 0, 2);

    public List<GameObject> ballsPrefabs = new List<GameObject>();
    public List<GameObject> powerUpPrefabs = new List<GameObject>();
    public GameObject[] balls;
    public int WaveCount { get; private set; }
    public float DicreaseSpawnTime { get; private set; } = 0f;
    const float dicreaseInterval = 0.1f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        WaveCount = 0;
        DicreaseSpawnTime = 0f;

        Invoke("SpawnBalls", 0f);
        Invoke("SpawnPowerUp", 0f);
    }

    private void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    void SpawnBalls()
    {
        if (!gameManager.GameIsOver)
        {
            CreateBall();

            float randomSpawnDelay = Random.Range(1.2f - DicreaseSpawnTime, 2.4f - DicreaseSpawnTime);
            Invoke("SpawnBalls", randomSpawnDelay);
        }        
    }

    void CreateBall()
    {
        int randomIndex = Random.Range(0, ballsPrefabs.Count);
        Vector3 randomPos = new Vector3(Random.Range(minBorderX, maxBorderX), ballsPrefabs[randomIndex].transform.position.y, Random.Range(minBorderZ, maxBorderZ));
        float randomAngleY = Random.Range(0f, 360f);
        Vector3 randomEulerAngles = new Vector3(transform.eulerAngles.x, randomAngleY, transform.eulerAngles.z);


        if (CheckSpawnPos(randomPos))
        {
            CreateBall();
        }
        else
        {
            Instantiate(ballsPrefabs[randomIndex], randomPos, Quaternion.Euler(randomEulerAngles));
        }
    } 

    void SpawnPowerUp()
    {
        if (!gameManager.GameIsOver)
        {
            CreatePowerUp();

            float randomDelay = Random.Range(10f, 12f);
            Invoke("SpawnPowerUp", randomDelay);
        }
    }
    
    void CreatePowerUp()
    {
        int randomIndex = Random.Range(0, powerUpPrefabs.Count);
        Vector3 randomPos = new Vector3(Random.Range(minBorderX, maxBorderX), powerUpPrefabs[randomIndex].transform.position.y, Random.Range(minBorderZ, maxBorderZ));
        float randomAngleY = Random.Range(0f, 360f);
        Vector3 randomEulerAngles = new Vector3(transform.eulerAngles.x, randomAngleY, transform.eulerAngles.z);

        if (CheckSpawnPos(randomPos))
        {
            CreatePowerUp();
        }
        else
        {
            Instantiate(powerUpPrefabs[randomIndex], randomPos, Quaternion.Euler(randomEulerAngles));
        }
    }

    bool CheckSpawnPos(Vector3 spawnPos)
    {
        Collider[] colliders;
        colliders = Physics.OverlapBox(spawnPos, boxColliderChecker);
        if (colliders.Length > 0)
        {
            return true;
        }
        return false;
    }

    public void SpawnWave()
    {        
        if (WaveCount > 0)
        {
            scoreManager.WaveScoreUpdate();
        }
        CreateBall();
        CreateBall();
        CreateBall();
        CreateBall();
        WaveCount++;
    }

    public void DicreaseSpawnInterval()
    {
        DicreaseSpawnTime += dicreaseInterval;
    }
}

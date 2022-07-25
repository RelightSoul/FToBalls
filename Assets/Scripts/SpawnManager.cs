using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> ballsPrefabs = new List<GameObject>();
    private GameManager gameManager;

    float minBorderX = -52f;
    float maxBorderX = 50f;
    float minBorderZ = -23f;
    float maxBorderZ = 28f;
    const float multiplyValue = 1.5f;

    public float DicreaseSpawnTime { get; set; } = 0f;
    public float WaveScoreMultiply { get; private set; } = 1;
    public int WaveCount { get; private set; }
    public GameObject[] balls;


    Vector3 boxColliderChecker = new Vector3(7, 7, 7);

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        WaveCount = 0;
        DicreaseSpawnTime = 0;

        Invoke("SpawnBalls", 0);
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

    public void SpawnWave()
    {
        if (WaveCount > 0)
        {
            WaveScoreMultiply *= multiplyValue;
        }
        CreateBall();
        CreateBall();
        CreateBall();
        CreateBall();
        WaveCount++;
    }

    bool CheckSpawnPos(Vector3 spawnPos)
    {
        Collider[] colliders;
        colliders = Physics.OverlapBox(spawnPos, boxColliderChecker);
        if (colliders.Length > 0)
        {
            return false;
        }
        return true;
    }
}

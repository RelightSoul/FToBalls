using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private BallController ballController;
    const float difficultyTimeDicrease = 0.1f;
    const int maxBallsInGame = 10;

    public bool GameIsOver { get; private set; }

    private void Start()
    {
        DataManager.Instance.playerScore = 0;
        GameIsOver = false;
        spawnManager = FindObjectOfType<SpawnManager>();
        ballController = FindObjectOfType<BallController>();

        spawnManager.SpawnWave();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ball") == null && !GameIsOver)
        {
            spawnManager.SpawnWave();
            DifficultyIncrease();
            ballController.SpeedIncrease();
        }
        if (spawnManager.balls.Length >= maxBallsInGame)
        {
            DataManager.Instance.SavePlayer();
            GameOver();
        }
    }

    void DifficultyIncrease()
    {
        spawnManager.DicreaseSpawnTime += difficultyTimeDicrease;
    }

    public void GameOver()
    {
        GameIsOver = true;
    }
}

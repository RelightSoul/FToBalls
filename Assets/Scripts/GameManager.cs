using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private BallController ballController;
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
        if (spawnManager.balls.Length == 0 && !GameIsOver)
        {
            ballController.SpeedIncrease();
            spawnManager.DicreaseSpawnInterval();            
            spawnManager.SpawnWave();
        }
        if (spawnManager.balls.Length >= maxBallsInGame)
        {
            DataManager.Instance.SavePlayer();
            GameOver();
        }
    }

    public void GameOver()
    {
        GameIsOver = true;
    }
}

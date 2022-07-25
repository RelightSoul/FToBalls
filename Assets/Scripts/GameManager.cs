using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private BallController ballController;
    private float difficultyTimeDicrease = 0.1f;

    public int Score { get; private set; }
    public bool GameIsOver { get; private set; }

    private void Start()
    {
        Score = 0;
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
        if (spawnManager.balls.Length >= 10)
        {
            GameOver();
        }
    }

    void DifficultyIncrease()
    {
        spawnManager.DicreaseSpawnTime += difficultyTimeDicrease;
    }

    public void ScoreUpdate(int scoreIncrease)
    {
        Score += Mathf.RoundToInt(scoreIncrease * spawnManager.WaveScoreMultiply);
    }

    public void GameOver()
    {
        GameIsOver = true;
    }
}

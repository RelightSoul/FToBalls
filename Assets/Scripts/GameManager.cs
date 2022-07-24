using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private BallController ballController;
    private float difficultyTimeDicrease = 0.1f;
    public int score;

    private void Start()
    {
        score = 0;
        spawnManager = FindObjectOfType<SpawnManager>();
        ballController = FindObjectOfType<BallController>();

        spawnManager.SpawnWave();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ball") == null)
        {
            spawnManager.SpawnWave();
            DifficultyIncrease();
            ballController.SpeedIncrease();
        }
    }

    void DifficultyIncrease()
    {
        spawnManager.DicreaseSpawnTime += difficultyTimeDicrease;
    }

    public void ScoreUpdate(int scoreIncrease)
    {
        score += Mathf.RoundToInt(scoreIncrease * spawnManager.WaveScoreMultiply);
    }
}

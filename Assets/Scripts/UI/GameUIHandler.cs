using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private ScoreManager scoreManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplyText;
    public TextMeshProUGUI ballsText;
    public GameObject gameMenu;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void LateUpdate()
    {
        scoreText.text = $"{DataManager.Instance.PlayerScore}";
        multiplyText.text = $"x{Math.Round(scoreManager.WaveScoreMultiply,2)}";
        ballsText.text = $"{spawnManager.balls.Length}";

        if (gameManager.GameIsOver)
        {
            gameMenu.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToMainMenu()
    {
        DataManager.Instance.LoadData();
        SceneManager.LoadScene(0);
    }
}

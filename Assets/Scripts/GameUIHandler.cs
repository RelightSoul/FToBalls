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

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplyText;
    public TextMeshProUGUI ballsText;
    public GameObject gameMenu;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void LateUpdate()
    {
        scoreText.text = $"{DataManager.Instance.playerScore}";
        multiplyText.text = $"x{Math.Round(spawnManager.WaveScoreMultiply,2)}";
        ballsText.text = $"{spawnManager.balls.Length}";

        if (gameManager.GameIsOver)
        {
            gameMenu.SetActive(true);
        }
    }

    public void Restart()
    {
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        DataManager.Instance.LoadPlayer();
        SceneManager.LoadScene(0);
    }
}

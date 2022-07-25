using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        scoreText.text = $"{gameManager.Score}";
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
        SceneManager.LoadScene(0);
    }
}

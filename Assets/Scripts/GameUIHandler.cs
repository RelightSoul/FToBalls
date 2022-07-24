using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameUIHandler : MonoBehaviour
{
    private GameManager gameManager;
    private SpawnManager spawnManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplyText;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void LateUpdate()
    {
        scoreText.text = $"{gameManager.score}";
        multiplyText.text = $"x{Math.Round(spawnManager.WaveScoreMultiply,2)}";
    }
}

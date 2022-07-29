using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private BallController ballController;
    const int maxBallsInGame = 100;
    public int ClickDamage { get; set; } = 1;

    public List<AudioClip> gameMusic;
    public bool GameIsOver { get; private set; }

    private void Start()
    {
        GetRandomMusic();
        DataManager.Instance.PlayerScore = 0;
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
        if (spawnManager.balls.Length >= maxBallsInGame && !GameIsOver)
        {
            DataManager.Instance.SaveData();
            GameOver();
        }
    }

    public void GameOver()
    {
        GameIsOver = true;
    }
    
    private void GetRandomMusic()
    {
        int randomClipIndex = Random.Range(0, gameMusic.Count);
        gameObject.GetComponent<AudioSource>().PlayOneShot(gameMusic[randomClipIndex]);
    }
}

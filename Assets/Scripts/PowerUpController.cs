using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : BallController
{
    private const float lifeTimer = 24f;
    private const float activeTimer = 12f;
    public float volume = 0.6f;
    private Vector3 PowerUpSpeed = new Vector3(0f, 0f, 40f);

    private protected override void Start()
    {
        ballVector3Speed = PowerUpSpeed;
        base.Start();
        PowerUpLifeTimer();
    }

    private protected override void OnMouseDown()
    {
        if (!gameManager.GameIsOver)
        {
            gameObject.SetActive(false);
            scoreManager.ScoreUpdate();
        }
    }

    void PowerUpLifeTimer()
    {
        Invoke("Deactivate", activeTimer);
        Invoke("Destroy", lifeTimer);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    } 

    private void Deactivate()
    {
        gameObject.SetActive(false);
    } 
}

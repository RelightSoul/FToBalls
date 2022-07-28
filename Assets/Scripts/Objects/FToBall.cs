using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FToBall : PowerUpController
{
    private int fBallHealth = 1;

    public override int Health { get => fBallHealth; set => fBallHealth = value; }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        DestroyBalls();
    }

    void DestroyBalls()
    {
        foreach (GameObject ball in spawnManager.balls)
        {
            scoreManager.ScoreUpdate();
            Destroy(ball);
        }
    }
}

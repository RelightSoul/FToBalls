using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FToBall : PowerUpController
{
    public AudioClip fToBallSound;

    private protected override void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(fToBallSound, Camera.main.transform.position, volume);
        base.OnMouseDown();
        Invoke("DestroyBalls", 2.4f);
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

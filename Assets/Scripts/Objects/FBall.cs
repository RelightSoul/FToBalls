using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBall : BallController
{
    private void OnDestroy()
    {
        foreach (GameObject ball in spawnManager.balls)
        {
            Destroy(ball);
        }
    }
}

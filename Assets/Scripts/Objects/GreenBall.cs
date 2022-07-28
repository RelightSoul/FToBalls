using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : BallController
{
    private int greenBallHealth = 1;
    Vector3 greenBallVector3Speed = new Vector3(0, 0, 28f);

    private protected override void Start()
    {
        ballVector3Speed = greenBallVector3Speed;
        health = greenBallHealth;
        base.Start();
    }
}

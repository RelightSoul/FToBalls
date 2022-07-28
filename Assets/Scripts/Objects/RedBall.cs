using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : BallController
{
    private int redBallHealth = 2;
    Vector3 redBallVector3Speed = new Vector3(0, 0, 24f);

    private protected override void Start()
    {
        ballVector3Speed = redBallVector3Speed;
        health = redBallHealth;
        base.Start();
    }
}

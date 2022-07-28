using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : BallController
{
    private int blueBallHealth = 3;
    Vector3 blueBallVector3Speed = new Vector3(0, 0, 20f);

    private protected override void Start()
    {
        ballVector3Speed = blueBallVector3Speed;
        health = blueBallHealth;
        base.Start();
    }
}

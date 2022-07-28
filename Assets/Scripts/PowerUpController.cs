using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpController : BallController
{
    public abstract int Health { get; set; }
    private const float lifeTime = 15f;

    private protected override void Start()
    {
        health = Health;
        base.Start();
        PowerUpLifeTimer();
    }

    void PowerUpLifeTimer()
    {
        Invoke("Destroy", lifeTime);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBall : PowerUpController
{
    private int freezeBallHealth = 1;

    public override int Health { get => freezeBallHealth; set => freezeBallHealth = value; }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }
}

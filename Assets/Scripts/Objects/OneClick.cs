using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneClick : PowerUpController
{
    private int oneClickHealth = 1;

    public override int Health { get => oneClickHealth; set => oneClickHealth = value; }

    private protected override void Start()
    {
        base.Start();
    }

    public override void OnMouseDown()
    {
        clickDamage = 3;
        base.OnMouseDown();
    }   
}

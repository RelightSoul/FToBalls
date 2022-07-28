using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBall : PowerUpController
{
    private int freezeBallHealth = 1;
    public static float freeze = 1f;

    public override int Health { get => freezeBallHealth; set => freezeBallHealth = value; }

    public override void OnMouseDown()
    {
        Freeze();
        base.OnMouseDown();
    }

    public void Freeze()
    {
        freeze = 0f;
        Invoke("Unfreeze", 3f);
    }
    void Unfreeze()
    {
        freeze = 1f;
    }
}

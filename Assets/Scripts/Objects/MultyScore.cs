using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyScore : PowerUpController
{
    private int multyScoreHealth = 1;
    public const float multyValue = 2f;

    public override int Health { get => multyScoreHealth; set => multyScoreHealth = value; }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        scoreManager.CurrentScoreByClick *= multyValue;
        scoreManager.SetConstValue();
    }
}
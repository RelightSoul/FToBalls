using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyScore : BallController
{
    public const float multyValue = 2f;

    private void OnMouseDown()
    {
        if (!gameManager.GameIsOver)
        {
            scoreManager.ScoreUpdate();
            health--;
        }
        scoreManager.currentScoreByClick *= multyValue;
        scoreManager.SetConstValue();
    }
}
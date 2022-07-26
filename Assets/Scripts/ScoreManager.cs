using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float WaveScoreMultiply { get; private set; } = 1f;    
    const float waveMultiplyValue = 1.5f;

    public float scoreByClick { get; set; } = 10f;

    public void ScoreUpdate()
    {
        DataManager.Instance.PlayerScore += Mathf.RoundToInt(
            scoreByClick * WaveScoreMultiply);
    }

    public void WaveScoreUpdate()
    {
        WaveScoreMultiply *= waveMultiplyValue;
    }
}

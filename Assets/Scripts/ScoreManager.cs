using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float WaveScoreMultiply { get; private set; } = 1f;    
    const float waveMultiplyValue = 1.5f;

    public float CurrentScoreByClick { get; set; } = 10f;
    const float scoreByClick = 10f;

    public void ScoreUpdate()
    {
        DataManager.Instance.PlayerScore += Mathf.RoundToInt(
            CurrentScoreByClick * WaveScoreMultiply);
    }

    public void WaveScoreUpdate()
    {
        WaveScoreMultiply *= waveMultiplyValue;
    }

    public void SetConstValue(float duration)
    {
        StartCoroutine(DeValue(duration));
    }
    public IEnumerator DeValue(float duration)
    {
        yield return new WaitForSeconds(duration);
        CurrentScoreByClick = scoreByClick;
    }
}

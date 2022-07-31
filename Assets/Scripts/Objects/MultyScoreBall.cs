using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultyScoreBall : PowerUpController
{
    private GameUIHandler gameUI;
    public AudioClip multyScoreSound;
    private const float multyValue = 2f;
    private float multyScoreDuration = 7f;

    private protected override void Start()
    {
        gameUI = FindObjectOfType<GameUIHandler>();
        base.Start();
    }
    private protected override void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(multyScoreSound, Camera.main.transform.position, volume);
        base.OnMouseDown();
        Invoke("GetMultyScore", 1.7f);
    }

    void GetMultyScore()
    {
        scoreManager.scoreByClick *= multyValue;
        gameUI.multyScoreText.gameObject.SetActive(true);
        Invoke("Deactive", multyScoreDuration);
    }

    void Deactive()
    {
        scoreManager.scoreByClick /= multyValue;
        gameUI.multyScoreText.gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private Rigidbody ballRb;
    private Vector3 ballSpeedOffset;
    private Vector3 ballSpeedIncrease = new Vector3(0f, 0f, 3f);
    private const int scoreByClick = 10;

    public Vector3 ballVector3Speed;
    public int health;

    private void Start()
    {
        ballSpeedOffset = new Vector3(0f, 0f, 0f);
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ballRb.AddRelativeForce(ballVector3Speed + ballSpeedOffset, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            ContactPoint contactPoint = collision.contacts[0];
            ballVector3Speed = Vector3.Reflect(ballVector3Speed + ballSpeedOffset, contactPoint.normal);
        }
    }

    public virtual void OnMouseDown()
    {
        if (!gameManager.GameIsOver)
        {
            ScoreUpdate();
            health--;
            if (health == 0)
                Destroy(gameObject);
        }
    }

    public void SpeedIncrease()
    {
        ballSpeedOffset += ballSpeedIncrease;
    }

    public void ScoreUpdate()
    {
        DataManager.Instance.PlayerScore += Mathf.RoundToInt(scoreByClick * spawnManager.WaveScoreMultiply);
    }
}

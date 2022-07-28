using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private protected GameManager gameManager;
    private protected ScoreManager scoreManager;
    private protected SpawnManager spawnManager;

    private Rigidbody ballRb;
    private Vector3 ballSpeedOffset;
    private Vector3 ballSpeedIncrease = new Vector3(0f, 0f, 3f);

    public Vector3 ballVector3Speed;
    public int health;

    private void Start()
    {
        ballSpeedOffset = new Vector3(0f, 0f, 0f);
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (health == 0)
            Destroy(gameObject);

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

    private void OnMouseDown()
    {
        if (!gameManager.GameIsOver)
        {
            scoreManager.ScoreUpdate();
            health--;
        }
    }

    public void SpeedIncrease()
    {
        ballSpeedOffset += ballSpeedIncrease;
    }
}

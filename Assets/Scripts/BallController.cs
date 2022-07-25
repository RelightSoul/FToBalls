using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody ballRb;
    private Vector3 ballSpeedOffset;
    private Vector3 ballSpeedIncrease = new Vector3(0f, 0f, 2f);
    private const int scoreIncreaseByClick = 10;

    public Vector3 ballVector3Speed;
    public int health;

    private void Start()
    {
        ballSpeedOffset = new Vector3(0f, 0f, 0f);
        gameManager = FindObjectOfType<GameManager>();
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ballRb.AddRelativeForce(ballVector3Speed + ballSpeedOffset, ForceMode.Acceleration);

        DestroyOnBorders();
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
            gameManager.ScoreUpdate(scoreIncreaseByClick);
            health--;
            if (health == 0)
                Destroy(gameObject);
        }
    }

    void DestroyOnBorders()
    {
        float borderRangeX = 66f;
        float borderRangeY = 14f;
        float borderRangeZ = 44f;


        if (transform.position.x < -borderRangeX || transform.position.x > borderRangeX)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -borderRangeY || transform.position.y > borderRangeY)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -borderRangeZ || transform.position.z > borderRangeZ)
        {
            Destroy(gameObject);
        }
    }

    public void SpeedIncrease()
    {
        ballSpeedOffset += ballSpeedIncrease;
    }
}

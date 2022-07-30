using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private protected GameManager gameManager;
    private protected ScoreManager scoreManager;
    private protected SpawnManager spawnManager;
    [SerializeField] AudioClip ballClickSound;
    private float clickVolume = 0.15f;

    private Rigidbody ballRb;
    private Vector3 ballSpeedOffset;
    private Vector3 ballSpeedIncrease = new Vector3(0f, 0f, 3f);

    private protected Vector3 ballVector3Speed;
    private protected int health = 1;

    private protected virtual void Start()
    {
        ballSpeedOffset = new Vector3(0f, 0f, 0f);
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ballRb.AddRelativeForce(GetSpeed(), ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            ContactPoint contactPoint = collision.contacts[0];
            ballVector3Speed = Vector3.Reflect(GetSpeed(), contactPoint.normal);           
        }
    }

    private protected virtual void OnMouseDown()
    {
        if (!gameManager.GameIsOver)
        {
            AudioSource.PlayClipAtPoint(ballClickSound, Camera.main.transform.position, clickVolume);
            scoreManager.ScoreUpdate();
            health -= gameManager.ClickDamage;
            if (health == 0)
                Destroy(gameObject);
        }
    }

    public void SpeedIncrease()
    {
        ballSpeedOffset += ballSpeedIncrease;
    }

    private Vector3 GetSpeed()
    {        
        return (ballVector3Speed + ballSpeedOffset) * FreezeBall.freeze;        
    }
}

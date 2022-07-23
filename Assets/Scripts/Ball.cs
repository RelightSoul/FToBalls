using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    public Vector3 ballVector3;

    private void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ballRb.AddForce(ballVector3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contactPoint = collision.contacts[0];
        ballVector3 = Vector3.Reflect(ballVector3, contactPoint.normal);
    }
}

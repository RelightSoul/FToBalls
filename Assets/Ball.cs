using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
        //  потестить
        //  FindObjectOfType<Wall>();
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);   
    }
}

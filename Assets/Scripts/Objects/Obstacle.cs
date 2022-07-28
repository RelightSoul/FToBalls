using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float rotateSpeed;
    public bool isRotate;

    private void FixedUpdate()
    {
        if (isRotate)
            RotateObstacle();
    }

    void RotateObstacle()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }
}

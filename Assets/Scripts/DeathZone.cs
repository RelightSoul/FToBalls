using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private const float deathZoneRangeX = 66f;
    private const float deathZoneRangeY = 14f;
    private const float deathZoneRangeZ = 44f;

    private void FixedUpdate()
    {
        DestroyOnBorders();
    }

    void DestroyOnBorders()
    {
        if (transform.position.x < -deathZoneRangeX || transform.position.x > deathZoneRangeX)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -deathZoneRangeY || transform.position.y > deathZoneRangeY)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -deathZoneRangeZ || transform.position.z > deathZoneRangeZ)
        {
            Destroy(gameObject);
        }
    }
}

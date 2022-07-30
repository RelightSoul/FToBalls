using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}

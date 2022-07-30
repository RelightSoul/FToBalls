using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBall : PowerUpController
{
    public AudioClip freezeSound;
    private float freezeDuration = 3f;    
    public static float freeze = 1f;

    private protected override void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(freezeSound, Camera.main.transform.position, volume);
        base.OnMouseDown();
        Invoke("Freeze", 1.5f);
    }

    public void Freeze()
    {
        freeze = 0f;
        Invoke("Unfreeze", freezeDuration);
    }
    void Unfreeze()
    {
        freeze = 1f;
    }
}

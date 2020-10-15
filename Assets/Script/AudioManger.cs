using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    public void _ShipAudio()
    {
        AudioSource.PlayClipAtPoint(clip1, Camera.main.transform.position);
    }

    public void _SubmarineSound()
    {
        AudioSource.PlayClipAtPoint(clip2, Camera.main.transform.position);
    }
    public void PickUpSound()
    {
        AudioSource.PlayClipAtPoint(clip3, Camera.main.transform.position);
    }

}

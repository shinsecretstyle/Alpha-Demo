using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaySound : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip sound2;

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        AudioSource.PlayClipAtPoint(sound2, transform.position);
    }

}

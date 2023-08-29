using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    private AudioSource sound01;
    private AudioSource sound02;
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
    }
    public void OnClick()
    {
        sound01.PlayOneShot(sound01.clip);
    }
    public void OnMove()
    {
        sound02.PlayOneShot(sound02.clip);
        
    }
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow))
        {
            sound02.PlayOneShot(sound02.clip);
        }
    }*/
}
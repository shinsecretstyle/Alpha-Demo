using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Renderer cubeRend;
    public AudioClip sound1;
    AudioSource SE;

    void Start()
    {
        cubeRend = GetComponent<Renderer>();
        cubeRend.material.color = new Color(1, 1, 1, 1); //îí
        SE = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    private void OnNotesKey() {
        if (SystemStatus.IsPaused == false)
        {
            StartCoroutine("HitColor");
            SE.PlayOneShot(sound1);
        }
    }
    IEnumerator HitColor()
    {
        cubeRend.material.color = new Color(255, 255, 255, 1); //white
        yield return new WaitForSeconds(0.15f);
        cubeRend.material.color = new Color(1, 1, 1, 1); //ÅhÅf
    }

}
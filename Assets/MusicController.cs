using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float waitTime;
    public Transform MainCamera;
    public AudioClip Music1;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 2.7f;
        MainCamera = GameObject.Find("Main Camera").transform;

    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime < 0) {
            AudioSource.PlayClipAtPoint(Music1,MainCamera.position);
            waitTime = 10000f;
        }
    }
}

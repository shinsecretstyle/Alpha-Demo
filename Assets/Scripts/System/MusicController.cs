using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float waitTime;
    public Transform MainCameraTransform;
    public AudioClip Music1;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 1.35f;
        MainCameraTransform = GameObject.Find("Main Camera").transform;

    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime < 0) {
            AudioSource.PlayClipAtPoint(Music1,MainCameraTransform.position);
            waitTime = 10000f;
        }
    }
}

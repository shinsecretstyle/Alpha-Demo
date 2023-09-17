using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float waitTime;
    public Transform MainCameraTransform;
    public AudioClip Music1;

    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 0f;
        MainCameraTransform = GameObject.Find("Main Camera").transform;
        AS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime < 0) {
            //GetComponent<AudioSource>().Play();
            AS.Play();
            //AudioSource.PlayClipAtPoint(Music1,MainCameraTransform.position);
            waitTime = 10000f;
        }
        if(SystemStatus.IsPaused == true)
        {
            AS.Pause();
            GetComponent<AudioSource>().Pause();
        }else
        //if(SystemStatus.MusicCanResume == true)
        {
            AS.UnPause();

        }

        
        
    }
}

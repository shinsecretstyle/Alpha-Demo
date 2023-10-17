using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float waitTime;
    public Transform MainCamera;
    public AudioClip Music1;

    AudioSource AS;

    public Transform RightspawnPoint;

    public TextAsset textJSON;

    [System.Serializable]
    public class NotesList
    {
        public float MusicTotalTime;
        public float beatFallSpeed;
    }

    public NotesList myNotesList = new NotesList();
    // Start is called before the first frame update
    void Start()
    {
        myNotesList = JsonUtility.FromJson<NotesList>(textJSON.text);

        waitTime = (RightspawnPoint.position.x - 0) / (myNotesList.beatFallSpeed / 60f);
        MainCamera = GameObject.Find("Main Camera").transform;
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

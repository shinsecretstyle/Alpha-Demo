using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite DefaultImage;
    public Sprite PressedImage;

    public bool canBePressed;
    public bool Pressed;

    public KeyCode keyToPress;

    private AudioSource NotesSE;
    public AudioClip NotesAudioClip1;

    public AudioClip Perfect;
    public AudioClip Good;
    public AudioClip OK;

    Transform MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

        NotesSE = GetComponent<AudioSource>();

        Pressed = false;
        MainCamera = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMode.Mode == "AttackOnly") {
            if (Mathf.Abs(gameObject.transform.position.x - 0) < 0.05)
            {
                float Goal = UnityEngine.Random.Range(0, 100);
                if (Goal >= 30)
                {
                    AudioSource.PlayClipAtPoint(Perfect, MainCamera.position);
                    Scores.Point += 4;
                    //Debug.Log("Perfect");
                    HK.result += 1;
                    Debug.Log("Perfect" + HK.result);
                }
                else if(Goal < 30 && Goal >= 10)
                {
                    AudioSource.PlayClipAtPoint(Good, MainCamera.position);
                    //Debug.Log("Good");
                    Scores.Point += 2;
                    HK.result += 1;
                    Debug.Log("Good" + HK.result);
                }
                else if (Goal < 10 && Goal >= 5)
                {
                    AudioSource.PlayClipAtPoint(OK, MainCamera.position);
                    //Debug.Log("ok");
                    Scores.Point += 1;
                    HK.result += 1;
                    Debug.Log("ok" + HK.result);
                }
                else if (Goal < 5)
                {
                    Scores.Point -= 1;
                    HK.result = 0;
                    Debug.Log("miss");
                }
                
                Destroy(gameObject);
            }
        }
    }

    private void OnNotesKey()
    {
        
        if (GameMode.Mode != "AttackOnly")
        {
            if (canBePressed)
            {

                //theSR.sprite = PressedImage;


                if (Mathf.Abs(gameObject.transform.position.x - 0) < 0.1)
                {
                    AudioSource.PlayClipAtPoint(Perfect, MainCamera.position);
                    Scores.Point += 4;
                    //Debug.Log("Perfect");
                    HK.result += 1;
                }
                if (Mathf.Abs(gameObject.transform.position.x - 0) > 0.1 && Mathf.Abs(gameObject.transform.position.x - 0) < 0.2)
                {
                    AudioSource.PlayClipAtPoint(Good, MainCamera.position);
                    //Debug.Log("Good");
                    Scores.Point += 2;
                    HK.result += 1;
                }
                if (Mathf.Abs(gameObject.transform.position.x - 0) > 0.2)
                {
                    AudioSource.PlayClipAtPoint(OK, MainCamera.position);
                    //Debug.Log("ok");
                    Scores.Point += 1;
                    HK.result += 1;
                }
                Pressed = true;



                Destroy(gameObject);

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            if (Pressed == false && GameMode.Mode != "AttackOnly")
            {
                Scores.Point -= 1;
                HK.result = 0;
            }
            Destroy(gameObject);
        }
    }
}

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

    }
    
    private void OnNotesKey()
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
            if (Pressed == false)
            {
                Scores.Point -= 1;
                HK.result = 0;
            }
            Destroy(gameObject);
        }
    }
}

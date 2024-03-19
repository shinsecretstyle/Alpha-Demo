using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    public static string from;
    private SpriteRenderer theSR;
    public Sprite DefaultImage;
    public Sprite PressedImage;

    public bool canBePressed;
    public bool Pressed;

    private AudioSource NotesSE;
    public AudioClip NotesAudioClip1;

    public AudioClip Perfect;
    public AudioClip Good;
    public AudioClip OK;

    public GameObject Perfecttext;
    public GameObject Goodtext;
    public GameObject OKtext;
    public GameObject Badtext;

    public GameObject PerfectSE;
    public GameObject GoodSE;
    public GameObject OKSE;

    float scrollSpeed;
    GameObject notesMaker;

    Transform textpoint;

    Transform MainCamera;

    Transform SEpoint;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

        NotesSE = GetComponent<AudioSource>();

        Pressed = false;
        MainCamera = GameObject.Find("Main Camera").transform;
        textpoint = GameObject.Find("textpoint").transform;
        SEpoint = GameObject.Find("EndPoint").transform;

        notesMaker = GameObject.Find("SmartNotesMaker");
        scrollSpeed = notesMaker.GetComponent<SmartNotesMaker>().beatFallSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //move the notes
        transform.position -= new Vector3(scrollSpeed * Time.deltaTime / 60f, 0f, 0f);


        //for demo mode
        if (GameMode.Mode == "AttackOnly") {

            if (canBePressed) {
                if (Mathf.Abs(gameObject.transform.position.x - 0) < 0.05)
                {
                    float Goal = UnityEngine.Random.Range(0, 100);
                    if (Goal >= 30)
                    {
                        AudioSource.PlayClipAtPoint(Perfect, MainCamera.position);
                        Scores.Point += 4;
                        HK.result += 1;
                        Debug.Log("Perfect" + HK.result);
                        AttackMaker.TotalAttack += 1;
                        AttackMaker.SpecialAttack += 1;
                        notesIsPerfect();
                    }
                    else if (Goal < 30 && Goal >= 10)
                    {
                        AudioSource.PlayClipAtPoint(Good, MainCamera.position);
                        Scores.Point += 2;
                        HK.result += 1;
                        Debug.Log("Good" + HK.result);
                        AttackMaker.TotalAttack += 1;
                        AttackMaker.SpecialAttack += 1;
                        notesIsGood();
                    }
                    else if (Goal < 10 && Goal >= 5)
                    {
                        AudioSource.PlayClipAtPoint(OK, MainCamera.position);
                        Scores.Point += 1;
                        HK.result += 1;
                        Debug.Log("ok" + HK.result);
                        AttackMaker.TotalAttack += 1;
                        AttackMaker.SpecialAttack += 1;
                        notesIsOk();
                    }
                    else if (Goal < 5)
                    {
                        Scores.Point -= 1;
                        HK.result = 0;
                        Debug.Log("miss");
                        if (BuffController.PraiseOfPain)
                        {
                            AttackMaker.SpecialAttack = 0;
                            Instantiate(Badtext, textpoint.transform);
                        }
                    }
                    Destroy(gameObject);
                }
            }
        }
    }

    //note is press at the perfect time
    void notesIsPerfect()
    {
        Instantiate(Perfecttext, textpoint.transform);
        Instantiate(PerfectSE, SEpoint.transform);
    }

    //note is press at the good time
    void notesIsGood()
    {
        Instantiate(Goodtext, textpoint.transform);
        Instantiate(GoodSE, SEpoint.transform);
    }

    //note is press at the ok time
    void notesIsOk()
    {
        Instantiate(OKtext, textpoint.transform);
        Instantiate(OKSE, SEpoint.transform);
    }


    private void OnNotesKey()
    {
        
        if (GameMode.Mode != "AttackOnly")
        {
            if (canBePressed)
            {

                //theSR.sprite = PressedImage;


                if (Mathf.Abs(gameObject.transform.position.x - 0) <= 0.1)
                {
                    AudioSource.PlayClipAtPoint(Perfect, MainCamera.position);
                    Scores.Point += 4;
                    //Debug.Log("Perfect");
                    HK.result += 1;
                    AttackMaker.TotalAttack += 1;
                    AttackMaker.SpecialAttack += 1;
                   
                    Instantiate(Perfecttext, textpoint.transform);
                    Instantiate(PerfectSE, SEpoint.transform);
                }
                if (Mathf.Abs(gameObject.transform.position.x - 0) > 0.1 && Mathf.Abs(gameObject.transform.position.x - 0) <= 0.3)
                {
                    AudioSource.PlayClipAtPoint(Good, MainCamera.position);
                    //Debug.Log("Good");
                    Scores.Point += 2;
                    HK.result += 1;
                    AttackMaker.TotalAttack += 1;
                    AttackMaker.SpecialAttack += 1;
                    Instantiate(Goodtext, textpoint.transform);
                    Instantiate(GoodSE, SEpoint.transform);
                }
                if (Mathf.Abs(gameObject.transform.position.x - 0) > 0.3 && Mathf.Abs(gameObject.transform.position.x - 0) <= 0.5)
                {
                    AudioSource.PlayClipAtPoint(OK, MainCamera.position);
                    //Debug.Log("ok");
                    Scores.Point += 1;
                    HK.result += 1;
                    AttackMaker.TotalAttack += 1;
                    AttackMaker.SpecialAttack += 1;
                    Instantiate(OKtext, textpoint.transform);
                    Instantiate(OKSE, SEpoint.transform);
                }
                if (Mathf.Abs(gameObject.transform.position.x - 0) > 0.5)
                {
                    
                    //Debug.Log("ok");
                    Scores.Point -= 1;
                    HK.result = 0;
                    
                    Instantiate(Badtext, textpoint.transform);
                }
                Pressed = true;

                //Debug.Log(AttackMaker.TotalAttack + "Total Attack one time");

                Destroy(gameObject);

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NotesLeft" && scrollSpeed < 0)
        {
            canBePressed = true;
        }
        if (other.tag == "NotesRight" && scrollSpeed > 0)
        {
            canBePressed = true;
        }

    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "NotesLeft" && scrollSpeed < 0)
        {
            canBePressed = false;
            if (Pressed == false && GameMode.Mode != "AttackOnly")
            {
                Scores.Point -= 1;
                HK.result = 0;
                Instantiate(Badtext, textpoint.transform);
            }
            Destroy(gameObject);
        }
        if (other.tag == "NotesRight" && scrollSpeed > 0)
        {
            canBePressed = false;
            if (Pressed == false && GameMode.Mode != "AttackOnly")
            {
                Scores.Point -= 1;
                HK.result = 0;
                Instantiate(Badtext, textpoint.transform);
            }
            Destroy(gameObject);
        }

    }
}

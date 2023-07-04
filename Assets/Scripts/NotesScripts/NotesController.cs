using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    private NoteObject theNO;
    private SpriteRenderer theSR;
    public Sprite DefaultImage;
    public Sprite PressedImage;
    /*
    private Sprite typeAImage;
    private Sprite typeBImage;
    private Sprite typeCImage;
    private Sprite typeDImage;
    */
    public KeyCode keyToPress;


    // Start is called before the first frame update
    void Start()
    {
        //theSR = GetComponent<SpriteRenderer>();
        //theNO = GetComponent<NoteObject>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (theNO.canBePressed == true)
        {

            if (Input.GetKeyDown(keyToPress))
            {
                theSR.sprite = PressedImage;
            }

            if (Input.GetKeyUp(keyToPress))
            {
                theSR.sprite = DefaultImage;
            }
        }*/
    }
}

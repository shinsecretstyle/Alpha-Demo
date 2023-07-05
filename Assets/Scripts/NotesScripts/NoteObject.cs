using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    
    private SpriteRenderer theSR;

    public Sprite DefaultImage;
    public Sprite PressedImage;
    
    public bool canBePressed;

    public KeyCode keyToPress;


    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        //While in the middle
        if (canBePressed)
        {
            //Detect pressing
            if (Input.GetKeyDown(keyToPress) || gamepadPressed())
            {
                theSR.sprite = PressedImage;


                if (Mathf.Abs(gameObject.transform.position.x - 0) < 0.1)
                {
                    Scores.Point += 4;
                    Debug.Log("Perfect");

                }
                if (Mathf.Abs(gameObject.transform.position.x - 0) > 0.1 && Mathf.Abs(gameObject.transform.position.x - 0) < 0.2)
                {
                    Debug.Log("Good");
                    Scores.Point += 2;
                }
                if (Mathf.Abs(gameObject.transform.position.x - 0) > 0.2)
                {
                    Debug.Log("ok");
                    Scores.Point += 1;
                }
                

                //Kill the Object
                Destroy(gameObject);

            }
        }

        // }
    }

    //If enter the collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

    }

    //If exit the collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            Scores.Point -= 1;
            Destroy(gameObject);
        }
    }

    private bool gamepadPressed()
    {
        bool isPressed = false;
        if (DualSenseGamepadHID.current.crossButton.wasPressedThisFrame //X Button

            || DualSenseGamepadHID.current.circleButton.wasPressedThisFrame //O Button

            || DualSenseGamepadHID.current.squareButton.wasPressedThisFrame //Square Button

            || DualSenseGamepadHID.current.triangleButton.wasPressedThisFrame //Triangle Button

            || DualSenseGamepadHID.current.dpad.up.wasPressedThisFrame //UP

            || DualSenseGamepadHID.current.dpad.down.wasPressedThisFrame //DOWN

            || DualSenseGamepadHID.current.dpad.right.wasPressedThisFrame //LEFT

            || DualSenseGamepadHID.current.dpad.left.wasPressedThisFrame) //Right
        {
            return true;
        }
        return isPressed;
    }
}

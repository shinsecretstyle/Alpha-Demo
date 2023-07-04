using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    //public int Score;
    private SpriteRenderer theSR;
    public Sprite DefaultImage;
    public Sprite PressedImage;
    //private Transform theTF;
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


        //判定位置入る確認
        if (canBePressed)
        {
            //合っているボタンを押すと実行する
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
                

                //削除
                Destroy(gameObject);



                //合っているボタン離すと実行する
                //if (Input.GetKeyUp(keyToPress))
                //{

                //    theSR.sprite = DefaultImage;
                //}
            }
        }

        // }
    }

    //判定位置イン
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

    }

    //判定位置アウト
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
        if (DualSenseGamepadHID.current.crossButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.circleButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.squareButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.triangleButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.up.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.down.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.right.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.left.wasPressedThisFrame)
        {
            return true;
        }
        return isPressed;
    }
}

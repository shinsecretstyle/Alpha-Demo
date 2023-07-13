using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HK : MonoBehaviour
{
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;

    public Sprite MissImage4;

    //private int id;
    public static int result;
    private SpriteRenderer theSR;
    public float CD = 2f;
    // Start is called before the first frame update
    void Start()
    {
        result = 1;
        theSR = GetComponent<SpriteRenderer>();
        //id = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CD -= Time.deltaTime;
        if (CD < 0 && OnNotesKey())
        {
            if (result % 3 == 1)
            {
                theSR.sprite = Image1;
            }
            else if (result % 3 == 2)
            {
                theSR.sprite = Image2;
            }
            else if (result % 3 == 0 && result != 0)
            {
                theSR.sprite = Image3;
            }
            CD = 2f;
        }
        if (result == 0)
        {
            theSR.sprite = MissImage4;
            CD = -1;
        }
        //if (DualSenseGamepadHID.current.leftShoulder.wasPressedThisFrame)
        //{

        //    theSR.sprite = AttackImage1;
        //}
        //if (DualSenseGamepadHID.current.leftTrigger.wasPressedThisFrame)
        //{
        //    theSR.sprite = AttackImage2;
        //}

        //if (DualSenseGamepadHID.current.rightShoulder.wasPressedThisFrame)
        //{
        //    theSR.sprite = AttackImage3;
        //}

        //if (DualSenseGamepadHID.current.rightTrigger.wasPressedThisFrame)
        //{
        //    theSR.sprite = AttackImage4;
        //}
    }
    //private bool gamepadPressed()
    //{
    //    bool isPressed = false;

    //    if (DualSenseGamepadHID.current.crossButton.wasPressedThisFrame ||
    //        DualSenseGamepadHID.current.circleButton.wasPressedThisFrame ||
    //        DualSenseGamepadHID.current.squareButton.wasPressedThisFrame ||
    //        DualSenseGamepadHID.current.triangleButton.wasPressedThisFrame ||
    //        DualSenseGamepadHID.current.dpad.up.wasPressedThisFrame ||
    //        DualSenseGamepadHID.current.dpad.down.wasPressedThisFrame ||
    //        DualSenseGamepadHID.current.dpad.right.wasPressedThisFrame ||
    //        DualSenseGamepadHID.current.dpad.left.wasPressedThisFrame)
    //    {
    //        isPressed = true;
    //    }
    //    return isPressed;
    //}
    private bool OnNotesKey()
    {
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.LowLevel;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        //Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
        //Gamepad.current[GamepadButton.LeftShoulder];

        /*if (Gamepad.current.aButton.wasPressedThisFrame)//x
        {
            Debug.Log("x1");
        }
        if (Gamepad.current.bButton.wasPressedThisFrame)//circle
        {
            Debug.Log("o1");
        }
        if (Gamepad.current.xButton.wasPressedThisFrame)//square
        {
            Debug.Log("sqare1");
        }
        if (Gamepad.current.yButton.wasPressedThisFrame)//triangel
        {
            Debug.Log("tri1");
        }
        */
        //aButton=crossButton=X
        //bButton=circleButton=O
        //xButton=squareButton=square
        //yButton=triangleButton=triangle
        //leftStickButton=L3=l3
        //rightStickButton=R3=r3
        //leftTrigger=L2=l2
        //rightTrigger=R2=r2
        //leftShoulder=L1=l1
        //rightShoulder=R1=r1
        //dpad.up,down,right,left
        

        if (DualSenseGamepadHID.current.optionsButton.wasPressedThisFrame)
        {
            Debug.Log("www");
        }

        if (DualSenseGamepadHID.current.dpad.up.wasPressedThisFrame)
        {
            Debug.Log("eee");
        }


    }
}

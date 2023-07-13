using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class CharactorController : MonoBehaviour
{
    public Sprite AttackImage1;
    public Sprite AttackImage2;
    public Sprite AttackImage3;
    public Sprite AttackImage4;

    private int id;
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        id = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (DualSenseGamepadHID.current.leftShoulder.wasPressedThisFrame
            || DualSenseGamepadHID.current.leftTrigger.wasPressedThisFrame
            || DualSenseGamepadHID.current.rightShoulder.wasPressedThisFrame
            || DualSenseGamepadHID.current.rightTrigger.wasPressedThisFrame) {
            id++;
        }
        if (id % 4 == 1)
        {
            theSR.sprite = AttackImage1;
        }
        else if (id % 4 == 2)
        {
            theSR.sprite = AttackImage2;
        }
        else if (id % 4 == 3)
        {
            theSR.sprite = AttackImage3;
        }
        else if ((id % 4) == 0) {
            theSR.sprite = AttackImage4;
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
}

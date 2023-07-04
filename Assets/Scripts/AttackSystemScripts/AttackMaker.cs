using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class AttackMaker : MonoBehaviour
{
    public KeyCode Attacker1;
    public KeyCode Attacker2;
    public KeyCode Attacker3;
    public KeyCode Attacker4;

    public GameObject AttackRange1;
    public Transform AttackRange1Point;

    public GameObject AttackRange2;
    public Transform AttackRange2Point;

    public GameObject AttackRange3;
    public Transform AttackRange3Point;

    public GameObject AttackRange4;
    public Transform AttackRange4Point;

    //public float AttackTimes = 0.4f;

    //public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Attacker1)||DualSenseGamepadHID.current.leftShoulder.wasPressedThisFrame) 
        {
            Debug.Log("Attack1");
            Instantiate(AttackRange1, AttackRange1Point.position, new Quaternion(0f, 0f, 0f, 0f));
        }
        if(Input.GetKeyDown(Attacker2) || DualSenseGamepadHID.current.leftTrigger.wasPressedThisFrame) 
        {
            Debug.Log("Attack2");
            Instantiate(AttackRange2, AttackRange2Point.position, new Quaternion(0f, 0f, 0f, 0f));
        }
        
        if(Input.GetKeyDown(Attacker3) || DualSenseGamepadHID.current.rightShoulder.wasPressedThisFrame) 
        {
            Debug.Log("Attack3");
            Instantiate(AttackRange3, AttackRange3Point.position, new Quaternion(0f, 0f, 0f, 0f));
        }

        if (Input.GetKeyDown(Attacker4) || DualSenseGamepadHID.current.rightTrigger.wasPressedThisFrame)
        {
            Debug.Log("Attack4");
            Instantiate(AttackRange4, AttackRange4Point.position, new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}

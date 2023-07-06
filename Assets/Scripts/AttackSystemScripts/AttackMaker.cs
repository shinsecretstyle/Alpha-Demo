using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

    public GameObject SpecialAttack;
    public Transform SpecialAttackPoint;

    public GameObject SpecialAttack2;
    public Transform SpecialAttackPoint2;
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
            StartCoroutine(Vibration(0.1f, 0));
        }
        if(Input.GetKeyDown(Attacker2) || DualSenseGamepadHID.current.leftTrigger.wasPressedThisFrame) 
        {
            Debug.Log("Attack2");
            Instantiate(AttackRange2, AttackRange2Point.position, new Quaternion(0f, 0f, 0f, 0f));
            StartCoroutine(Vibration(0.3f, 0.2f));
        }
        
        if(Input.GetKeyDown(Attacker3) || DualSenseGamepadHID.current.rightShoulder.wasPressedThisFrame) 
        {
            Debug.Log("Attack3");
            Instantiate(AttackRange3, AttackRange3Point.position, new Quaternion(0f, 0f, 0f, 0f));
            StartCoroutine(Vibration(0.6f, 0.4f));
        }

        if (Input.GetKeyDown(Attacker4) || DualSenseGamepadHID.current.rightTrigger.wasPressedThisFrame)
        {
            Debug.Log("Attack4");
            Instantiate(AttackRange4, AttackRange4Point.position, new Quaternion(0f, 0f, 0f, 0f));
            StartCoroutine(Vibration(1.2f, 0.7f));
        }

        if (DualSenseGamepadHID.current.leftStickButton.wasPressedThisFrame)
        {
            Debug.Log("Special Skill1");
            Instantiate(SpecialAttack,SpecialAttackPoint.position, new Quaternion(0f, 0f, 0f, 0f));
            //StartCoroutine(Vibration(1.2f, 0.7f));
        }

        if (DualSenseGamepadHID.current.rightStickButton.wasPressedThisFrame)
        {
            Debug.Log("Special Skill2");
            Instantiate(SpecialAttack2, SpecialAttackPoint2.position, new Quaternion(0f, 0f, 0f, 0f));
            //StartCoroutine(Vibration(1.2f, 0.7f));
        }
    }

    private static IEnumerator Vibration
        (
        float lowFrequency,
        float highFrequency
        )
    {
        var gamepad = DualSenseGamepadHID.current;
        gamepad.SetMotorSpeeds( lowFrequency, highFrequency );
        yield return new WaitForSeconds( 0.05f );
        gamepad.SetMotorSpeeds( 0, 0 );
    }
}

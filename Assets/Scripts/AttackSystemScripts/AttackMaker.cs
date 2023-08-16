using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public GameObject TotalAttacks;
    public Transform TotalAttacksPoint;
    public GameObject SpecialAttack;
    public Transform SpecialAttackPoint;

    public GameObject SpecialAttack2;
    public Transform SpecialAttackPoint2;

    AudioSource theAS;
    Transform MainCamera;

    public AudioClip Range1SE;
    public AudioClip Range2SE;
    public AudioClip Range3SE;
    public AudioClip Range4SE;

    private Gamepad gamepad;
    private bool HasGamepad;

    private bool canAttack;
    private float AttackCD;

    public static int TotalAttack = 0;
    //public float AttackTimes = 0.4f;

    //public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        theAS = GetComponent<AudioSource>();

        MainCamera = GameObject.Find("Main Camera").transform;

        if (Gamepad.current != null)
        {
            HasGamepad = true;
            Debug.Log("connected");
        }
        AttackCD = -1;
        canAttack = true;
    }

    private void OnAttackRange1()
    {
        if (canAttack)
        {
            ResetCD();
            AudioSource.PlayClipAtPoint(Range1SE, MainCamera.position);
            Instantiate(AttackRange1, AttackRange1Point.position, new Quaternion(0f, 0f, 0f, 0f));
            Queen.id++;
            if (HasGamepad)
            {
                StartCoroutine(Vibration(0.1f, 0));
            }
        }

    }
    private void OnAttackRange2()
    {
        if (canAttack)
        {
            ResetCD();
            AudioSource.PlayClipAtPoint(Range2SE, MainCamera.position);
            Instantiate(AttackRange2, AttackRange2Point.position, new Quaternion(0f, 0f, 0f, 0f));
            Queen.id++;
            if (HasGamepad)
            {
                StartCoroutine(Vibration(0.3f, 0.2f));
            }
        }
    }
    private void OnAttackRange3()
    {
        if (canAttack)
        {
            ResetCD();
            AudioSource.PlayClipAtPoint(Range3SE, MainCamera.position);
            Instantiate(AttackRange3, AttackRange3Point.position, new Quaternion(0f, 0f, 0f, 0f));
            Queen.id++;
            if (HasGamepad)
            {
                StartCoroutine(Vibration(0.6f, 0.4f));
            }
        }
    }
    private void OnAttackRange4()
    {
        if (canAttack)
        {
            ResetCD();
            AudioSource.PlayClipAtPoint(Range4SE, MainCamera.position);
            Instantiate(AttackRange4, AttackRange4Point.position, new Quaternion(0f, 0f, 0f, 0f));
            Queen.id++;
            if (HasGamepad)
            {
                StartCoroutine(Vibration(1.2f, 0.7f));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null)
        {
            HasGamepad = true;
            
        }
        AttackCD -= Time.deltaTime;
        if (AttackCD < 0)
        {
            canAttack = true;
        }
        else if (AttackCD > 0) { 
            canAttack = false;
        }
        if (TotalAttack == 5) {
            Instantiate(TotalAttacks, TotalAttacksPoint.position, new Quaternion(0f, 0f, 0f, 0f));
            TotalAttack = 0;
        }
    }

    private IEnumerator Vibration
        (
        float lowFrequency,
        float highFrequency
        )
    {
        gamepad = Gamepad.current;
        gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
        yield return new WaitForSeconds(0.05f);
        gamepad.SetMotorSpeeds(0, 0);
    }
    private void ResetCD()
    {
        AttackCD = 0f;
    }
}

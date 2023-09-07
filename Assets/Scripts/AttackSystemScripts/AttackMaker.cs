using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackMaker : MonoBehaviour
{

    public GameObject AttackRange1;
    public Transform AttackRange1Point;

    public GameObject AttackRange2;
    public Transform AttackRange2Point;

    //auto attack
    public GameObject TotalAttacks;
    public Transform TotalAttacksPoint;

    //public GameObject SpecialAttack;
    //public Transform SpecialAttackPoint;

    //public GameObject SpecialAttack2;
    //public Transform SpecialAttackPoint2;

    AudioSource theAS;
    Transform MainCamera;

    public AudioClip Range1SE;
    public AudioClip Range2SE;


    private Gamepad gamepad;
    private bool HasGamepad;

    private bool canAttack;
    private float AttackCD;

    public static int TotalAttack = 0;

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

        //Auto Attack when finished 5 notes
        if (TotalAttack == 5) {
            Instantiate(TotalAttacks, TotalAttacksPoint.position, new Quaternion(0f, 0f, 0f, 0f));
            Queen.id++;
            TotalAttack = 0;
            if (HasGamepad)
            {
                StartCoroutine(Vibration(0.1f, 0.2f));
            }
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

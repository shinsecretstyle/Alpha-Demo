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

    public Transform AttackRange3Point;

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

    //private bool canAttack;
    private float AttackCD;

    public static int TotalAttack = 0;
    public static int SpecialAttack = 0;

    public GameObject SA1;//5combo
    public GameObject SA2;//+2
    public GameObject SA3;//+5

    public GameObject SA4;
    public GameObject PauseMenu;
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
        //canAttack = true;
    }

    private void OnAttackRange1()
    {
        //if (canAttack)
        //{
        //    ResetCD();
        //    AudioSource.PlayClipAtPoint(Range1SE, MainCamera.position);
        //    Instantiate(AttackRange1, AttackRange1Point.position, new Quaternion(0f, 0f, 0f, 0f));
        //    Queen.id++;
        //    if (HasGamepad)
        //    {
        //        StartCoroutine(Vibration(0.1f, 0));
        //    }
        //}
        SystemStatus.isAttackUp = !SystemStatus.isAttackUp;

    }
    private void OnAttackRange2()
    {
        //if (canAttack)
        //{
        //    ResetCD();
        //    AudioSource.PlayClipAtPoint(Range2SE, MainCamera.position);
        //    Instantiate(AttackRange2, AttackRange2Point.position, new Quaternion(0f, 0f, 0f, 0f));
        //    Queen.id++;
        //    if (HasGamepad)
        //    {
        //        StartCoroutine(Vibration(0.3f, 0.2f));
        //    }
        //}
        SystemStatus.isAttackUp = !SystemStatus.isAttackUp;
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
            //canAttack = true;
        }
        else if (AttackCD > 0) { 
            //canAttack = false;
        }

        //Auto Attack when finished 5 notes
        if (TotalAttack == 1) {
            if (!SystemStatus.isAttackUp)//Air Attack
            {
                Instantiate(AttackRange1, AttackRange1Point.position, new Quaternion(0f, 0f, 0f, 0f));
                AudioSource.PlayClipAtPoint(Range1SE, MainCamera.position);
                if (HasGamepad)
                {
                    StartCoroutine(Vibration(0.1f, 0.2f));
                }

                if (BuffController.CuteAggression) {
                    Instantiate(AttackRange1, AttackRange1Point.position, new Quaternion(0f, 0f, 0f, 0f));
                    AudioSource.PlayClipAtPoint(Range1SE, MainCamera.position);
                    if (HasGamepad)
                    {
                        StartCoroutine(Vibration(0.1f, 0.2f));
                    }
                    //Debug.Log("1");
                }
            }
            else//Land Attack
            {
                Instantiate(AttackRange2, AttackRange2Point.position, new Quaternion(0f, 0f, 0f, 0f));
                AudioSource.PlayClipAtPoint(Range2SE, MainCamera.position);
                if (HasGamepad)
                {
                    StartCoroutine(Vibration(0.4f, 0.6f));
                }

                if (BuffController.CuteAggression){
                    Instantiate(AttackRange2, AttackRange2Point.position, new Quaternion(0f, 0f, 0f, 0f));
                    AudioSource.PlayClipAtPoint(Range2SE, MainCamera.position);
                    if (HasGamepad)
                    {
                        StartCoroutine(Vibration(0.4f, 0.6f));
                    }
                    //Debug.Log("1");
                }
            }
            Queen.id++;
            TotalAttack = 0;
            
        }

        if(SystemStatus.IsPaused == false)
        {
            GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
           
        }
        if(SystemStatus.IsPaused == true) 
        {
            GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        }


        if (BuffController.PraiseOfPain) {
            if(SpecialAttack == 5)
            {
                Attack.AttackRange3 = Attack.AttackRange1 * 6;
                Instantiate(SA1, AttackRange3Point.position, new Quaternion(0f, 0f, 0f, 0f));
                Debug.Log("1");
                SpecialAttack = 0;
            }
            
        }
        if (BuffController.BlatantMalice){
            if (SpecialAttack == 2)
            {
                Attack.AttackRange3 = Attack.AttackRange1 * 2;
                Instantiate(SA2, AttackRange3Point.position, new Quaternion(0f, 0f, 0f, 0f));
                Debug.Log("2");
                SpecialAttack = 0;
            }
        }
        if (!BuffController.ChildishEmbrace) {
            if (SpecialAttack == 5)
            {
                Attack.AttackRange3 = Attack.AttackRange1 * 4;
                Instantiate(SA3, AttackRange3Point.position, new Quaternion(0f, 0f, 0f, 0f));
                Debug.Log("3");
                SpecialAttack = 0;
            }
        }

        if(GameController.GameClear == 1)
        {
            BuffController.Resetall();
            Instantiate(SA4, AttackRange3Point.position, new Quaternion(0f, 0f, 0f, 0f));
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

    public void OnPause()
    {
        if (SystemStatus.IsPaused == false)
        {
            Instantiate(PauseMenu);
        }
        
    }
}

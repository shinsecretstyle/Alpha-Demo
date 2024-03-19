using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string Name;
    public int MaxHp;
    public int HP;
    public int Speed;
    public int ATK;
    public float CD;
    public Slider HpSlider;
    public bool hasSE;
    public int Bonus;

    public Sprite DefaultImage;
    public Sprite AttackedImage;
    public AudioClip AttackSE1;

    bool CanMove;
    bool CanAttack;
    bool CanAttackFence1;
    bool CanAttackFence2;
    bool CanAttackGate;

    float AttackCD;
    bool AttackCDisOk;

    bool Fence1CanAttack;
    float Fence1CD;
    bool Fence2CanAttack;
    float Fence2CD;

    AudioSource theSE;
    Transform MainCamera;
    SpriteRenderer theSR;
    Animator theAnim;

    // Initialization
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        HpSlider.value = 1;
        HP = MaxHp;

        CanMove = true;
        CanAttack = false;


        AttackCD = CD;
        AttackCDisOk = true;
        CanAttackFence1 = false;
        CanAttackFence2 = false;
        CanAttackGate = false;

        //damage from fence(make game easy)
        Fence1CD = 1f;
        Fence2CD = 1f;

        theAnim = GetComponent<Animator>();
        theSE = GetComponent<AudioSource>();

        MainCamera = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime / 60f, 0f, 0f);
        }

        HpSlider.value = (float)HP / (float)MaxHp;


        if (HP < 1)
        {
            Scores.Point += Bonus;
            Destroy(gameObject);
        }

        if (Fence1CanAttack)
        {
            Fence1CD -= Time.deltaTime;
            if (Fence1CD < 0)
            {
                Fence1CD = 1f;
                HP -= Fence1.ATK;
            }
        }
        if (Fence2CanAttack)
        {
            Fence2CD -= Time.deltaTime;
            if (Fence2CD < 0)
            {
                Fence2CD = 1f;
                HP -= Fence2.ATK;
            }
        }

        if (CanAttack)
        {
            if (AttackCDisOk)
            {

                theAnim.Play("Attack", 0, 0.0f);
                if (hasSE)
                {
                    AudioSource.PlayClipAtPoint(AttackSE1, MainCamera.position);
                }
                AttackCDisOk = false;
                if (theAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
                {
                    if (CanAttackGate)
                    {

                        Gate.HP -= ATK;

                    }
                    else if (CanAttackFence1)
                    {

                        Fence1.HP -= ATK;
                    }
                    else if (CanAttackFence2)
                    {

                        Fence2.HP -= ATK;
                    }
                }
            }
            if (AttackCDisOk == false)
            {
                AttackCD -= Time.deltaTime;
            }
            if (AttackCD < 0)
            {
                AttackCDisOk = true;
                AttackCD = CD;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "AttackRange1")
        {
            HP -= Attack.AttackRange1;
            //theSR.sprite = AttackedImage;
        }
        if (other.tag == "AttackRange2")
        {
            HP -= Attack.AttackRange2;
            //theSR.sprite = AttackedImage;
        }
        if (other.tag == "AttackRange3")
        {
            HP -= Attack.AttackRange3;
            //theSR.sprite = AttackedImage;
        }
        if (other.tag == "AttackRange4")
        {
            HP -= Attack.AttackRange4;
            //theSR.sprite = AttackedImage;
        }

        if (other.tag == "TotalAttack")
        {
            HP -= (Attack.AttackRange4) / 2;
            //theSR.sprite = AttackedImage;

        }

        if (other.tag == "Gate")
        {
            CanAttack = true;
            CanMove = false;
            CanAttackGate = true;
        }

        if (other.tag == "Fence1")
        {
            CanAttack = true;
            CanMove = false;
            CanAttackFence1 = true;
            Fence1CanAttack = true;
        }
        if (other.tag == "Fence2")
        {
            CanAttack = true;
            CanMove = false;
            CanAttackFence2 = true;
            Fence2CanAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "AttackRange1")
        {

            //theSR.sprite = DefaultImage;
        }
        if (other.tag == "AttackRange2")
        {

            //theSR.sprite = DefaultImage;
        }
        if (other.tag == "AttackRange3")
        {

            //theSR.sprite = DefaultImage;
        }
        if (other.tag == "AttackRange4")
        {

            //theSR.sprite = DefaultImage;
        }

        if (other.tag == "Gate")
        {
            CanAttack = false;
            CanMove = true;
            CanAttackGate = false;
        }

        if (other.tag == "Fence1")
        {
            CanAttack = false;
            CanMove = true;
            CanAttackFence1 = false;
            AttackCD = CD;
            AttackCDisOk = true;
            Fence1CanAttack = false;

        }
        if (other.tag == "Fence2")
        {
            CanAttack = false;
            CanMove = true;
            CanAttackFence2 = false;
            AttackCD = CD;
            AttackCDisOk = true;
            Fence2CanAttack = false;
        }
    }
}

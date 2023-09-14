using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class DestructKnightEnemy : MonoBehaviour
{
    public int HP;

    public int Speed;

    public Slider HpSlider;

    private int MaxHp = AllEnemy.DestructKnightEnemy.MaxHP;

    public int ATK;
    public bool CanMove;

    public bool CanAttack;
    public bool CanAttackFence1;
    public bool CanAttackFence2;
    public bool CanAttackGate;

    public Sprite DefaultImage;
    public Sprite AttackedImage;

    private SpriteRenderer theSR;

    Animator theAnim;

    public float AttackCD;
    public float Fence1CD;
    public float Fence2CD;

    public bool AttackCDisOk;
    public bool Fence1CanAttack;
    public bool Fence2CanAttack;
    private AudioSource theSE;
    Transform MainCamera;

    public AudioClip AttackSE1;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        HpSlider.value = 1;
        HP = MaxHp;
        CanMove = true;
        CanAttack = false;
        Speed = AllEnemy.DestructKnightEnemy.Speed;
        ATK = AllEnemy.DestructKnightEnemy.ATK;
        AttackCD = AllEnemy.DestructKnightEnemy.CD;
        AttackCDisOk = true;
        CanAttackFence1 = false;
        CanAttackFence2 = false;
        CanAttackGate = false;
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
            Destroy(gameObject);
        }

        if (Fence1CanAttack) {
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
                AudioSource.PlayClipAtPoint(AttackSE1, MainCamera.position);
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
                AttackCD = AllEnemy.DestructKnightEnemy.CD;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "AttackRange1")
        {
            HP -= Attack.AttackRange1;
            theSR.sprite = AttackedImage;
        }
        if (other.tag == "AttackRange2")
        {
            HP -= Attack.AttackRange2;
            theSR.sprite = AttackedImage;
        }
        if (other.tag == "AttackRange3")
        {
            HP -= Attack.AttackRange3;
            theSR.sprite = AttackedImage;
        }
        if (other.tag == "AttackRange4")
        {
            HP -= Attack.AttackRange4;
            theSR.sprite = AttackedImage;
        }

        if (other.tag == "TotalAttack")
        {
            HP -= (Attack.AttackRange4)/2;
            theSR.sprite = AttackedImage;
            
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

            theSR.sprite = DefaultImage;
        }
        if (other.tag == "AttackRange2")
        {

            theSR.sprite = DefaultImage;
        }
        if (other.tag == "AttackRange3")
        {

            theSR.sprite = DefaultImage;
        }
        if (other.tag == "AttackRange4")
        {

            theSR.sprite = DefaultImage;
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
            AttackCD = AllEnemy.DestructKnightEnemy.CD;
            AttackCDisOk = true;
            Fence1CanAttack = false;

        }
        if (other.tag == "Fence2")
        {
            CanAttack = false;
            CanMove = true;
            CanAttackFence2 = false;
            AttackCD = AllEnemy.DestructKnightEnemy.CD;
            AttackCDisOk = true;
            Fence2CanAttack = false;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MKnightEnemy : MonoBehaviour
{
    public int HP;

    public int Speed;

    public int ATK;

    public Slider HpSlider;

    private int MaxHp = 7;

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

    public bool AttackCDisOk;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        HpSlider.value = 1;
        HP = 7;
        ATK = 2;
        Speed = 460;
        CanMove = true;
        CanAttack = false;
        CanAttackFence1 = false;
        CanAttackFence2 = false;
        CanAttackGate = false;

        AttackCD = 2f;
        AttackCDisOk = true;
        theAnim = GetComponent<Animator>();
        
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

        if (CanAttack)
        {
            if (AttackCDisOk)
            {
                
                
                AttackCDisOk = false;

                if (CanAttackGate)
                {
                    theAnim.Play("Attack", 0, 0.0f);
                    Gate.HP -= ATK;
                }
                else if (CanAttackFence1) 
                {
                    theAnim.Play("Attack", 0, 0.0f);
                    //if (theAnim.GetCurrentAnimatorStateInfo(1).IsName("Attack")){
                    //    Debug.Log("aaaaaaa");
                    //}
                    Fence1.HP -= ATK;
                }
                else if (CanAttackFence2)
                {
                    theAnim.Play("Attack", 0, 0.0f);
                    Fence2.HP -= ATK;
                }
            }
            if (AttackCDisOk == false)
            {
                AttackCD -= Time.deltaTime;
            }
            if (AttackCD < 0)
            {
                AttackCDisOk = true;
                AttackCD = 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Attack")
        {
            HP--;
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
        }
        if (other.tag == "Fence2")
        {
            CanAttack = true;
            CanMove = false;
            CanAttackFence2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Attack")
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
        }
        if (other.tag == "Fence2")
        {
            CanAttack = false;
            CanMove = true;
            CanAttackFence2 = false;
        }
    }
}
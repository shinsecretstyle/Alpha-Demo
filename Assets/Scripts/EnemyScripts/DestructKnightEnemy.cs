using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructKnightEnemy : MonoBehaviour
{
    public int HP;

    public int Speed;

    public Slider HpSlider;

    private int MaxHp = 8;

    public bool CanMove;

    public bool CanAttack;

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
        HP = 8;
        Speed = 40;
        CanMove = true;
        CanAttack = false;
        AttackCD = 3f;
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
                theAnim.Play("Attack", 0, 0.0f);
                AttackCDisOk = false;
                Gate.HP -= 5;
            }
            if (AttackCDisOk == false)
            {
                AttackCD -= Time.deltaTime;
            }
            if (AttackCD < 0)
            {
                AttackCDisOk = true;
                AttackCD = 1f;
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

        if (other.tag == "Wall")
        {
            CanMove = false;
            CanAttack = true;
        }

        if (other.tag == "Gate")
        {
            CanMove = false;
            CanAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Attack")
        {

            theSR.sprite = DefaultImage;
        }

        if (other.tag == "Wall")
        {
            CanMove = true;
            CanAttack = false;
        }

        if (other.tag == "Gate")
        {
            CanMove = true;
            CanAttack = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemyObject : MonoBehaviour
{
    public int HP;

    public int Speed;

    public Slider HpSlider;

    private int MaxHp = 15;

    public bool CanMove;

    public bool CanAttack;

    public Sprite DefaultImage;

    public Sprite AttackedImage;

    private SpriteRenderer theSR;


    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        HpSlider.value = 1;
        HP = 15;
        Speed = 30;
        CanMove = true;
        CanAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime / 60f, 0f, 0f);
        }

        if (CanAttack)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime / 60f, 0f, 0f);
        }

        HpSlider.value = (float)HP / (float)MaxHp;

        if (HP < 1)
        {
            Destroy(gameObject);
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
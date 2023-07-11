using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmartEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theAnim = GetComponent<Animator>();
        HpSlider.value = 1;
        HP = 7;
        Speed = 60;
        CanMove = true;
        CanAttack = false;
        MaxHp = 10;
        
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
            //if (AttackCDisOk)
            //{
            //    theAnim.Play("Attack", 0, 0.0f);
            //    AttackCDisOk = false;
            //}
            //if (AttackCDisOk == false)
            //{
            //    AttackCD -= Time.deltaTime;
            //}
            //if (AttackCD < 0)
            //{
            //    AttackCDisOk = true;
            //    AttackCD = 1f;
            //}
        }
    }
}

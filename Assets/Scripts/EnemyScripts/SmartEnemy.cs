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

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

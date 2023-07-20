using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class Queen : MonoBehaviour
{
    public Sprite AttackImage1;
    public Sprite AttackImage2;
    public Sprite AttackImage3;
    public Sprite AttackImage4;

    public static int id;
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        id = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (id % 3 == 1)
        {
            theSR.sprite = AttackImage1;
        }
        else if (id % 3 == 2)
        {
            theSR.sprite = AttackImage2;
        }
        else if (id % 3 == 0)
        {
            theSR.sprite = AttackImage3;
        }
    }
}

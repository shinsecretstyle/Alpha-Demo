using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HK : MonoBehaviour
{
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;

    public Sprite MissImage4;


    public static int result;
    private SpriteRenderer theSR;
    public float CD = 2f;
    // Start is called before the first frame update
    void Start()
    {
        result = 1;
        theSR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CD -= Time.deltaTime;
        if (CD < 0 && OnNotesKey() && GameMode.Mode != "AttackOnly")
        {
            if (result % 3 == 1)
            {
                theSR.sprite = Image1;
            }
            else if (result % 3 == 2)
            {
                theSR.sprite = Image2;
            }
            else if (result % 3 == 0 && result != 0)
            {
                theSR.sprite = Image3;
            }
            CD = 2f;
        }
        if (CD < 0 && (GameMode.Mode == "AttackOnly"))
        {
            if (result % 3 == 1)
            {
                theSR.sprite = Image1;
            }
            else if (result % 3 == 2)
            {
                theSR.sprite = Image2;
                
            }
            else if (result % 3 == 0 && result != 0)
            {
                theSR.sprite = Image3;
            }
            
            
            CD = 2f;
        }
        if (result == 0)
        {
            theSR.sprite = MissImage4;
            CD = -1;
        }
    }

    private bool OnNotesKey()
    {
        return true;
    }
}

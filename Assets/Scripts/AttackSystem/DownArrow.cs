using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrow: MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public Sprite S1;
    public Sprite S2;

    // Update is called once per frame
    void Update()
    {
        if (!SystemStatus.isAttackUp)
        {
            GetComponent<SpriteRenderer>().sprite = S1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = S2;
        }
    }
}

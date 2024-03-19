using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite S1;
    public Sprite S2;

    // Update is called once per frame
    void Update()
    {
        if (SystemStatus.isAttackUp)
        {
            GetComponent<SpriteRenderer>().sprite = S1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = S2;
        }
    }
}

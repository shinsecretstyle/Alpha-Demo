using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    public float AttackRemainingTimes=0.4f;

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > AttackRemainingTimes)
        {
            Destroy(gameObject);
        }
    }
}

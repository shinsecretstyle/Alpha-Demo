using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePorject : MonoBehaviour
{
    public float IceRemainingTimes = 50f;

    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > IceRemainingTimes)
        {
            Destroy(gameObject);
        }
    }
}

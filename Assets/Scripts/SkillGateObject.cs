using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGateObject : MonoBehaviour
{

    public float SkillGateRemainingTimes = 5f;

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > SkillGateRemainingTimes)
        {
            Destroy(gameObject);
        }
    }
}

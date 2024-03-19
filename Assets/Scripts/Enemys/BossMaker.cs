using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BossMaker : MonoBehaviour
{
    public GameObject Boss;

    public float time;

    public Transform BossPoint;

    public bool BossIsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        BossIsSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time>3f && !BossIsSpawned)
        {
            Instantiate(Boss, BossPoint.position, new Quaternion(0f, 0f, 0f, 0f));
            BossIsSpawned = true;
        }
        
    }
}

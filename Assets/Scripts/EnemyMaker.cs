using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyMaker : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;

    public float time;

    public Transform Enemy1Point;
    public Transform Enemy2Point;
    public Transform Enemy3Point;
    public Transform Enemy4Point;

    public bool e1;
    public bool e2;
    public bool e3;
    // Start is called before the first frame update
    void Start()
    {
        e1 = false; e2 = false; e3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if((time > 3) && (e1 == false)) {

            Instantiate(Enemy1, Enemy1Point.position, new Quaternion(0f, 0f, 0f, 0f));

            //Instantiate(Enemy1, Enemy3Point.position, new Quaternion(0f, 0f, 0f, 0f));
            e1 = true;
        }
        if((time > 4) && (e2 == false))
        {
            Instantiate(Enemy2, Enemy2Point.position, new Quaternion(0f, 0f, 0f, 0f));
            //Instantiate(Enemy2, Enemy3Point.position, new Quaternion(0f, 0f, 0f, 0f));
            e2 = true;
        }

        if((time > 9) && (e3 == false)) {

            Instantiate(Enemy3, Enemy3Point.position, new Quaternion(0f, 0f, 0f, 0f));

            time -= 9;
            e1 = false;
            e2 = false;
        }
    }
}

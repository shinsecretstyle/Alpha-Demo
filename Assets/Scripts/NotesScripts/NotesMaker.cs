using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMaker : MonoBehaviour
{
    public GameObject NotesA;

    public static int counts = 10;

    public DateTime StartedTime;
    
    private int i;
    float time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        StartedTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;

        if (time > 2f)
        {
            i++;
            time = time - 2f;
            

            if (i < counts)
            {
               

                i++;
                Instantiate(NotesA, new Vector3(i * -1.0f - 5f, 0, 0), Quaternion.identity);

                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public TextAsset textJSON;
    public float beatFallSpeed;
    public bool isStarted;

    public GameObject SmartNotesMaker;

    
    // Start is called before the first frame update
    void Start()
    {
        //beatFallSpeed = beatFallSpeed / 60f;
        SmartNotesMaker = GameObject.Find("SmartNotesMaker");
        beatFallSpeed = SmartNotesMaker.GetComponent<SmartNotesMaker>().beatFallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(beatFallSpeed * Time.deltaTime / 60f, 0f, 0f);
        
    }
    
}

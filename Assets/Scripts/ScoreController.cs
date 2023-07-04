using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    //public GameObject ScoreText;

    public int Score;
    public int PT;

    private Text ST;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        PT = 0;
        //this.ST = GameObject.Find("ScoreText").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score :  " + Scores.Point.ToString();

    }
    
}

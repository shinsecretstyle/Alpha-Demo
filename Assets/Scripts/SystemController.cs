using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.SceneManagement;

public class SystemController : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public bool isPaused;
    //UnityEngine.SceneManagement.Scene s1 = SceneManager.GetSceneByName("SmartNoteMaker");
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused != true)
        {
            if (DualSenseGamepadHID.current.optionsButton.isPressed)
            {
                SceneManager.LoadScene("SmartNoteMaker");
                Scores.Point = 0;
                //time.timescale = 0;
                //ispaused = true;
                //debug.log("paused");


            }
        }
        if (isPaused == true)
        {
            if (DualSenseGamepadHID.current.circleButton.isPressed)
            {

                Time.timeScale = 1;
                isPaused = false;
                Debug.Log("continue");
            }
        }

    }
}

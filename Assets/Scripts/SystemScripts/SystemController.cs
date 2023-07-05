using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class SystemController : MonoBehaviour
{

    public bool isPaused;
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

                Time.timeScale = 0;
                isPaused = true;
                Debug.Log("Paused");
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

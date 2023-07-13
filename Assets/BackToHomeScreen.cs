using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.SceneManagement;

public class BackToHomeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DualSenseGamepadHID.current.crossButton.wasPressedThisFrame) {
            SceneManager.LoadScene("Title");
        }
    }
}

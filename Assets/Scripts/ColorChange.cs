using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class ColorChange : MonoBehaviour
{
    private Renderer cubeRend;
    public KeyCode keyToPress1;
    public KeyCode keyToPress2;
    public KeyCode keyToPress3;
    public KeyCode keyToPress4;
    public AudioClip sound1;
    AudioSource SE;

    void Start()
    {
        cubeRend = GetComponent<Renderer>();
        cubeRend.material.color = new Color(1, 1, 1, 1); //îí
        SE = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(keyToPress1)
        //    || Input.GetKeyDown(keyToPress2)
        //    || Input.GetKeyDown(keyToPress3)
        //    || Input.GetKeyDown(keyToPress4))Input.GetKeyDown(keyToPress) || 
        if (gamepadPressed())
        {
            StartCoroutine("HitColor");
            SE.PlayOneShot(sound1);

        }
    }

    IEnumerator HitColor()
    {
        cubeRend.material.color = new Color(255, 255, 255, 1); //white
        yield return new WaitForSeconds(0.15f);
        cubeRend.material.color = new Color(1, 1, 1, 1); //ÅhÅf
    }
    private bool gamepadPressed()
    {
        bool isPressed = false;
        if (DualSenseGamepadHID.current.crossButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.circleButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.squareButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.triangleButton.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.up.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.down.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.right.wasPressedThisFrame ||
            DualSenseGamepadHID.current.dpad.left.wasPressedThisFrame)
        {
            return true;
        }
        return isPressed;
    }
}
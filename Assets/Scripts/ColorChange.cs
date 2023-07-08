using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class ColorChange : MonoBehaviour
{
    private Renderer cubeRend;
    public KeyCode keyToPress;
    void Start()
    {
        cubeRend = GetComponent<Renderer>();
        cubeRend.material.color = new Color(1, 1, 1, 1); //îí
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) || gamepadPressed())
        {
            StartCoroutine("HitColor");
        }
    }

    IEnumerator HitColor()
    {
        cubeRend.material.color = new Color(0, 1, 1, 1); //çï
        yield return new WaitForSeconds(0.15f);
        cubeRend.material.color = new Color(1, 1, 1, 1); //îí
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
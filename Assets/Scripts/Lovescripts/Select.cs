using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Select : MonoBehaviour
{
    private AudioSource sound01;
    private AudioSource sound02;

    public float timer = 0.2f;

    public bool isHolding = false;
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
    }
    public void OnClick()
    {
        sound01.PlayOneShot(sound01.clip);
    }
    public void OnMove()
    {
        sound02.PlayOneShot(sound02.clip);
        
    }
    public void OnMoving(InputAction.CallbackContext context) {
        if (context.interaction is HoldInteraction)
        {
            Debug.Log("123");
            isHolding = true;
        }
        else if (context.canceled) {
            
            isHolding = false;
        }
        
    }
    
    private void Update()
    {
        if (isHolding)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                sound02.PlayOneShot(sound02.clip);
                timer = 0.2f;
            }
        }
    }
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow))
        {
            sound02.PlayOneShot(sound02.clip);
        }
    }*/
}
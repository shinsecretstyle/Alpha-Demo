using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemController : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public bool isPaused;
    
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnPause() { 
        
    }
}

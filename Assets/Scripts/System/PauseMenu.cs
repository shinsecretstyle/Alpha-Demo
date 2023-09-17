using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SystemStatus.MusicCanResume = false;
        SystemStatus.IsPaused = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0f;
    }
    public void BackToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
        SystemStatus.IsPaused = false;
        Scores.Point = 0;
        Destroy(gameObject);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        SystemStatus.MusicCanResume = true;
        SystemStatus.IsPaused = false;
        Debug.Log("Resume");
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHomeScreen : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("Title");
        }
    }
    private void OnBackToHome()
    {
        SceneManager.LoadScene("Title");
    }
}

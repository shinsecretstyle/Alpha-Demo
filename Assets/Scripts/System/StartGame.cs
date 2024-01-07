using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    Animator animator;
    PlayerInput playerInput;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        BuffController.Resetall();
        timer = 2f;
        animator = GameObject.Find("CrossFade").GetComponent<Animator>();
        playerInput = gameObject.GetComponent<PlayerInput>();

        playerInput.SwitchCurrentActionMap("null");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer-= Time.deltaTime;
            if(timer < 0.2f)
            {
                //wait for 2s to controll
                playerInput.SwitchCurrentActionMap("Player");
            }
        }
    }

    private void OnPressAnyKey()
    {
        //SceneManager.LoadScene("Tutorial");
        LoadNextScene();
        
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScenes(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScenes(int SceneBuildIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneBuildIndex);
    }
}

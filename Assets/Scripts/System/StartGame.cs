using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        BuffController.Resetall();
        animator = GameObject.Find("CrossFade").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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

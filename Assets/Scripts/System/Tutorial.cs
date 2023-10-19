using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    Animator animator;

    private int id;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    public Sprite Image6;

    private float timer;

    bool isSwitched = false;
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        Scores.Point = 0;
        id = 1;
        timer = 100f;
        theSR = GetComponent<SpriteRenderer>();

        GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 99f && !isSwitched ) {
            //wait 1s for fade in
            GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        }
        if (timer < 0)
        {
            SceneManager.LoadScene("Title");
        }
        if (id == 1)
        {
            theSR.sprite = Image1;
        }
        if (id == 2)
        {
            theSR.sprite = Image2;
        }
        if (id == 3)
        {
            theSR.sprite = Image3;
        }
        if (id == 4)
        {
            theSR.sprite = Image6;
        }
        if (id == 55)
        {
            theSR.sprite = Image5;
        }
        if (id == 56)
        {
            theSR.sprite = Image6;
        }
        if (id == 5)
        {
            LoadNextScene();


        }

    }
    private void OnNextPage()
    {
        id++;
    }
    private void OnSkip()
    {
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadScenes(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScenes(int SceneBuildIndex)
    {
        //animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneBuildIndex);
    }

}

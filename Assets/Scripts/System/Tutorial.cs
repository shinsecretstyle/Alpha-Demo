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
        animator = GameObject.Find("CrossFade").GetComponent<Animator>();


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
            returnToTitle();
        }

        pageControll();

    }
    private void OnNextPage()
    {
        id++;
    }
    private void OnSkip()
    {
        FadeOut();
        LoadNextScene();
    }

    private void pageControll()
    {
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
            theSR.sprite = Image4;
        }
        if (id == 5)
        {
            theSR.sprite = Image5;
        }
        if (id == 6)
        {
            theSR.sprite = Image6;
        }
        if (id == 7)
        {
            FadeOut();
            LoadNextScene();

        }
    }

    private void returnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    private void FadeOut()
    {
        animator.SetTrigger("Start");
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScenes(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScenes(int SceneBuildIndex)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneBuildIndex);
    }

}

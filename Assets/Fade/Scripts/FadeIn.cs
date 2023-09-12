using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Fade fade;
    public void NextScene()
    {
        Action act = () => SceneManager.LoadScene("Love failure");
        float time = 1f;

        //1秒間フェードしてからにシーン移動する
        fade.FadeIn(time, act);
    }
}
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

        //1�b�ԃt�F�[�h���Ă���ɃV�[���ړ�����
        fade.FadeIn(time, act);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [SerializeField] Fade fade;
    // Start is called before the first frame update
    void Start()
    {
        float time = 1f;

        //1�b�ԃt�F�[�h���Ă���ɃV�[���ړ�����
        fade.FadeOut(time);
    }
}
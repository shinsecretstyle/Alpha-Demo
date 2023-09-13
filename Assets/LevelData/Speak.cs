using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speak : MonoBehaviour
{
    private string talks = "お は よ う 、 今 日 も い い 天 気 だ ね 。";
    private string[] words;
    public Text textLabel;
    public AudioClip sound;

    private void Update()
    {
        // 今回はPキーを押すと会話スタート
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Dialogue());
        }
    }

    // コルーチンを使って、１文字ごと表示する。
    IEnumerator Dialogue()
    {
        // 半角スペースで文字を分割する。
        words = talks.Split(' ');

        foreach (var word in words)
        {
            // 0.1秒刻みで１文字ずつ表示する。
            textLabel.text = textLabel.text + word;
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
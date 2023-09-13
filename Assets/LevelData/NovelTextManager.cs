using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class NovelTextManager : MonoBehaviour
{
    public Text novelText; //表示用テキスト
    public GameObject nextBtn; //次ボタン
    public AudioSource charSE; //1文字ずつの効果音
    public string[] sentences; //表示したい文章の配列
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplaySentence()); //文字送り開始
    }

    // Update is called once per frame
    void Update()
    {
        if (novelText.text == sentences[i]) //文章が完成したら、ボタンを表示
        {
            nextBtn.SetActive(true);
            if (i == (sentences.Length - 1)) //さらに最後の文章ならボタン非表示
            {
                nextBtn.SetActive(false);
            }

        }
        else
        {
            nextBtn.SetActive(false);
        }

    }
    IEnumerator DisplaySentence()
    {
        foreach (char x in sentences[i].ToCharArray()) //～.ToCharArray()はテキスト1文字ずつの配列
        {
            novelText.text += x; //1文字追加
            charSE.Play(); //効果音再生
            yield return new WaitForSeconds(0.1f); //0.1秒間隔
        }
    }
    public void OnClickNext()
    {
        if (i < sentences.Length - 1) //最後の文章でないなら
        {
            i++;
            novelText.text = ""; //現在の文章を白紙に
            StartCoroutine(DisplaySentence()); //次の文字送り開始
        }
    }
}
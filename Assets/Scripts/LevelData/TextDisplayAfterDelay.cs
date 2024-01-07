using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextDisplayAfterDelay : MonoBehaviour
{
    public Text textObject; // テキストUIをInspectorからアタッチする
    public Button button; // ボタンUIをInspectorからアタッチする
    public string targetText = "This is the target text."; // 表示したいテキスト

    private bool isDisplayingText = false;

    private void Start()
    {
        textObject.text = ""; // テキストを初期化
        textObject.gameObject.SetActive(false); // テキストを非表示にする

        button.onClick.AddListener(StartTextDisplay);
    }

    private void StartTextDisplay()
    {
        StartCoroutine(DisplayTextAfterDelay());
    }

    private IEnumerator DisplayTextAfterDelay()
    {
        yield return new WaitForSeconds(2.0f); // 2秒待つ

        textObject.gameObject.SetActive(true); // テキストを表示
        textObject.text = ""; // テキスト要素を初期化
        isDisplayingText = true;

        foreach (char character in targetText)
        {
            if (!isDisplayingText)
            {
                break; // ボタンが再度押されたら中断
            }

            textObject.text += character;
            yield return new WaitForSeconds(0.1f); // 0.1秒ごとに一文字表示
        }

        isDisplayingText = false;
    }

   
}

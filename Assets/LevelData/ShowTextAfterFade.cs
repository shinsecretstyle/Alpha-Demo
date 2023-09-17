using UnityEngine;
using TMPro;
using System.Collections;

public class ShowTextAfterFade : MonoBehaviour
{
    public ObjectFade objectFade; // ObjectFadeスクリプトがアタッチされたオブジェクト
    public TextMeshProUGUI textToShow;
    public float textSpeed = 0.1f; // 一文字ずつ表示される速度
    public float delayBeforeStart = 1.0f; // 表示開始前の待機時間

    private string fullText;
    private bool isTyping = false;
    private bool hasStartedTyping = false;

    void Start()
    {
        fullText = textToShow.text;
        textToShow.text = "";
    }

    void Update()
    {
        if (!isTyping && objectFade != null && !hasStartedTyping)
        {
            StartCoroutine(StartTyping());
            hasStartedTyping = true;
        }
    }

    IEnumerator StartTyping()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        isTyping = true;

        for (int i = 0; i < fullText.Length; i++)
        {
            textToShow.text += fullText[i];
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }
}
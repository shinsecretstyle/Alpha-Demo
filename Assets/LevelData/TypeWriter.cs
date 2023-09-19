using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeWriter : MonoBehaviour
{
    public Text textObject; // Text (Legacy) コンポーネントへの参照
    public float initialDelay = 2.0f; // ボタン押してから表示が始まるまでの初期待機時間
    public float delayDuration = 0.1f; // 文字の表示間隔

    private string displayText = ""; // 表示するテキスト
    private int currentCharIndex = 0;

    private void Start()
    {
        textObject.text = ""; // 最初はテキストを空にする
    }

    public void StartTyping()
    {
        displayText = "…へ、っ…？　…ふぅん……？　そ、そうなんだ……。　…。　…え、っと！　ぼくにして欲しいこととか…ある？\n（正しい返答ができたようだ…） "; // 表示したいテキストを設定
        currentCharIndex = 0;
        StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        yield return new WaitForSeconds(initialDelay); // 初期待機時間

        while (currentCharIndex < displayText.Length)
        {
            textObject.text += displayText[currentCharIndex];
            currentCharIndex++;

            yield return new WaitForSeconds(delayDuration); // 文字の表示間隔
        }
    }
}

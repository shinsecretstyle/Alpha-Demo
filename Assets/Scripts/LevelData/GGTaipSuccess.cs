using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーンの切り替えに必要な名前空間
using System.Collections;

public class GGTaipSuccess : MonoBehaviour
{
    public Text textObject; // Text (Legacy) コンポーネントへの参照
    public Text newMessageObject; // 新しいメッセージを表示する Text コンポーネントへの参照
    public float initialDelay = 2.0f; // ボタン押してから表示が始まるまでの初期待機時間
    public string newMessage = "新しいメッセージ"; // 表示したい新しいメッセージ
    public float delayDuration = 0.1f; // 文字の表示間隔

    private string displayText = ""; // 表示するテキスト
    private int currentCharIndex = 0;

    private void Start()
    {
        textObject.text = ""; // 最初はテキストを空にする
        newMessageObject.text = ""; // 新しいテキストも空にする
    }

    public void StartTyping()
    {
        displayText = "あああもう!!! 変な期待して損した!!・・・まあいいさ、\nこれも君 が提供してくれた余興だと思うことにするよ。\nほら、さっさと敵を倒すぞ!!\n                         （返答を間違えたようだ…） "; // 表示したいテキストを設定
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

        // 新しいテキストを表示
        newMessageObject.text = newMessage;

        // シーンを切り替える
        yield return new WaitForSeconds(2.0f); // 2秒待つ
        SceneManager.LoadScene("Buff4"); // 次のシーンの名前に切り替えるシーン名を指定
    }
}

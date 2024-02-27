using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーンの切り替えに必要な名前空間
using System.Collections;

public class TaipSuccess : MonoBehaviour
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
        displayText = "...はっ。そう、 好いてるんだ?僕を好いて..。\n...えっ? 〜っ!・・うへ、ちょ、見ないで、寄るな、\n下がれって不敬者!! ほ、ほら迎撃!さっさと迎撃行くぞ!!\n                            （正しい返答ができたようだ…）"; // 表示したいテキストを設定
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
        SceneManager.LoadScene("Buff3"); // 次のシーンの名前に切り替えるシーン名を指定
    }
}

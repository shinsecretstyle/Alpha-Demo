using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TextDisplayAfterDelay : MonoBehaviour
{
    public TMP_Text textObject; // TextMeshProのテキスト要素をInspectorからアタッチする
    public Button button; // ボタンUIをInspectorからアタッチする
    public float delayBeforeDisplay = 2.0f; // ボタンが押されてからテキストが表示されるまでの遅延時間（秒）
    public float textSpeed = 0.1f; // 文字の表示速度（一文字が表示される間隔、秒）

    private string targetText = "This is the target text."; // 表示したいテキスト
    private int currentIndex = 0;
    private bool isDisplayingText = false;

    private void Start()
    {
        // テキスト要素を初期化して非表示にする
        textObject.text = "";
        textObject.gameObject.SetActive(false);

        // ボタンのクリックイベントにStartTextDisplayメソッドを関連付ける
        button.onClick.AddListener(StartTextDisplay);
    }

    private void Update()
    {
        // テキストが表示中かつまだ全ての文字が表示されていない場合、次の文字を表示する
        if (isDisplayingText && currentIndex < targetText.Length)
        {
            textObject.text += targetText[currentIndex];
            currentIndex++;
            StartCoroutine(DisplayNextCharacter());
        }
    }

    private void StartTextDisplay()
    {
        // テキスト表示を遅延させて開始する
        StartCoroutine(StartDisplayAfterDelay());
    }

    private IEnumerator StartDisplayAfterDelay()
    {
        // 指定した遅延時間だけ待機してからテキスト表示を開始する
        yield return new WaitForSeconds(delayBeforeDisplay);

        // テキストを表示可能にし、初期化
        textObject.gameObject.SetActive(true);
        currentIndex = 0;
        textObject.text = "";
        isDisplayingText = true;

        // 最初の文字を表示し、その後の文字を表示するコルーチンを開始
        StartCoroutine(DisplayNextCharacter());
    }

    private IEnumerator DisplayNextCharacter()
    {
        // 指定したテキスト表示速度だけ待機してから次の文字を表示する
        yield return new WaitForSeconds(textSpeed);

        if (currentIndex < targetText.Length)
        {
            // まだ表示すべき文字が残っている場合、次の文字を表示
            StartCoroutine(DisplayNextCharacter());
        }
        else
        {
            // すべての文字が表示されたら表示終了
            isDisplayingText = false;
        }
    }
}

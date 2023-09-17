using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAppearance : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Button buttonToTrigger;
    public float characterAppearDelay = 0.1f; // 一文字ずつ表示される遅延時間

    private string fullText;
    private int currentCharacterIndex;
    private float timeUntilNextCharacter;

    private bool isAppearing = false;

    private void Start()
    {
        fullText = textMeshPro.text;
        textMeshPro.text = ""; // 最初はテキストを空にする
        currentCharacterIndex = 0;
        timeUntilNextCharacter = characterAppearDelay;

        // ボタンが押されたときのイベントを登録
        if (buttonToTrigger != null)
        {
            buttonToTrigger.onClick.AddListener(StartTextAppearance);
        }
    }

    private void Update()
    {
        if (isAppearing)
        {
            // 次の文字の表示時間をカウントダウン
            timeUntilNextCharacter -= Time.deltaTime;

            if (timeUntilNextCharacter <= 0f)
            {
                // 次の文字を表示
                textMeshPro.text += fullText[currentCharacterIndex];
                currentCharacterIndex++;

                // 全ての文字を表示したら停止
                if (currentCharacterIndex >= fullText.Length)
                {
                    isAppearing = false;
                }

                // 次の文字の表示時間をリセット
                timeUntilNextCharacter = characterAppearDelay;
            }
        }
    }

    private void StartTextAppearance()
    {
        // ボタンが押されたとき、テキスト表示を開始
        isAppearing = true;
    }
}

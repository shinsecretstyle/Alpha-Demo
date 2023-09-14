using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ButtonTextDisplay : MonoBehaviour
{
    public Button button;           // ボタンをアタッチする変数
    public Text textToDisplay;      // 表示するテキストをアタッチする変数
    public string displayText;      // 表示するテキスト内容
    public GameObject newImage;     // 別の画像を表示するための GameObject
    public InputAction moveAction;  // セレクト移動のアクション
    public InputAction pressAction; // ボタンを押すアクション

    private bool textDisplayed;     // テキストが表示されたかどうかのフラグ

    private void OnEnable()
    {
        moveAction.Enable();
        pressAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        pressAction.Disable();
    }

    private void Start()
    {
        // ボタンがクリックされたらテキストを表示
        button.onClick.AddListener(ShowText);
        button.Select(); // ボタンを初期選択状態にする
    }

    private void Update()
    {
        // セレクト移動のアクションを監視し、移動方向に合わせてボタンを選択
        if (moveAction.triggered)
        {
            Vector2 moveInput = moveAction.ReadValue<Vector2>();
            if (moveInput.y > 0.0f)
            {
                SelectButtonUp();
            }
            else if (moveInput.y < 0.0f)
            {
                SelectButtonDown();
            }
        }

        // ボタンを押すアクションを監視し、ボタンを押す
        if (pressAction.triggered)
        {
            PressButton();
        }
    }

    private void ShowText()
    {
        if (!textDisplayed)
        {
            textToDisplay.text = displayText;
            textDisplayed = true;

            // ボタンを非表示にする
            button.gameObject.SetActive(false);

            // 新しい画像を表示
            newImage.SetActive(true);
        }
    }

    private void SelectButtonUp()
    {
        // 上方向のセレクト移動
        Selectable previous = button.FindSelectableOnUp();
        if (previous != null)
        {
            previous.Select();
        }
    }

    private void SelectButtonDown()
    {
        // 下方向のセレクト移動
        Selectable next = button.FindSelectableOnDown();
        if (next != null)
        {
            next.Select();
        }
    }

    private void PressButton()
    {
        // ボタンを押すアクションがトリガーされたときの処理をここに追加
    }
}

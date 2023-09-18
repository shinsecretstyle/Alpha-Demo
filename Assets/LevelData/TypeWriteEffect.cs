using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriteEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _startButton;
    [SerializeField] private float _initialDelay = 2.0f; // ボタン押してから表示が始まるまでの初期待機時間
    [SerializeField] private float _delayDuration = 0.1f; // 文字の表示間隔

    private Coroutine _showCoroutine;

    private void Start()
    {
        _text.maxVisibleCharacters = 0; // 最初はテキストを非表示にする

        _startButton.onClick.AddListener(ShowText);
    }

    private void ShowText()
    {
        if (_showCoroutine != null)
            StopCoroutine(_showCoroutine);

        _showCoroutine = StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        yield return new WaitForSeconds(_initialDelay); // 初期待機時間

        var delay = new WaitForSeconds(_delayDuration);
        var length = _text.text.Length;

        for (var i = 0; i <= length; i++)
        {
            _text.maxVisibleCharacters = i;
            yield return delay;
        }

        _showCoroutine = null;
    }
}

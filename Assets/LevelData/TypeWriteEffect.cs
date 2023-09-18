using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriteEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _startButton;
    [SerializeField] private float _initialDelay = 2.0f; // �{�^�������Ă���\�����n�܂�܂ł̏����ҋ@����
    [SerializeField] private float _delayDuration = 0.1f; // �����̕\���Ԋu

    private Coroutine _showCoroutine;

    private void Start()
    {
        _text.maxVisibleCharacters = 0; // �ŏ��̓e�L�X�g���\���ɂ���

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
        yield return new WaitForSeconds(_initialDelay); // �����ҋ@����

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

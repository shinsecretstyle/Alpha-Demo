using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriteEffect : MonoBehaviour
{
    // �Ώۂ̃e�L�X�g
    [SerializeField] private TMP_Text _text;

    // ���̕�����\������܂ł̎���[s]
    [SerializeField] private float _delayDuration = 0.1f;

    private Coroutine _showCoroutine;

    /// <summary>
    /// �������艉�o��\������
    /// </summary>
    public void Show()
    {
        // �O��̉��o�����������Ă�����A��~
        if (_showCoroutine != null)
            StopCoroutine(_showCoroutine);

        // �P�������\�����鉉�o�̃R���[�`�������s����
        _showCoroutine = StartCoroutine(ShowCoroutine());
    }

    // �P�������\�����鉉�o�̃R���[�`��
    private IEnumerator ShowCoroutine()
    {
        // �ҋ@�p�R���[�`��
        // GC Alloc���ŏ������邽�߃L���b�V�����Ă���
        var delay = new WaitForSeconds(_delayDuration);

        // �e�L�X�g�S�̂̒���
        var length = _text.text.Length;

        // �P�������\�����鉉�o
        for (var i = 0; i < length; i++)
        {
            // ���X�ɕ\���������𑝂₵�Ă���
            _text.maxVisibleCharacters = i;

            // ��莞�ԑҋ@
            yield return delay;
        }

        // ���o���I�������S�Ă̕�����\������
        _text.maxVisibleCharacters = length;

        _showCoroutine = null;
    }
}
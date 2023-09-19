using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeWriter : MonoBehaviour
{
    public Text textObject; // Text (Legacy) �R���|�[�l���g�ւ̎Q��
    public float initialDelay = 2.0f; // �{�^�������Ă���\�����n�܂�܂ł̏����ҋ@����
    public float delayDuration = 0.1f; // �����̕\���Ԋu

    private string displayText = ""; // �\������e�L�X�g
    private int currentCharIndex = 0;

    private void Start()
    {
        textObject.text = ""; // �ŏ��̓e�L�X�g����ɂ���
    }

    public void StartTyping()
    {
        displayText = "�c�ցA���c�H�@�c�ӂ���c�c�H�@���A�����Ȃ񂾁c�c�B�@�c�B�@�c���A���ƁI�@�ڂ��ɂ��ė~�������ƂƂ��c����H\n�i�������ԓ����ł����悤���c�j "; // �\���������e�L�X�g��ݒ�
        currentCharIndex = 0;
        StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        yield return new WaitForSeconds(initialDelay); // �����ҋ@����

        while (currentCharIndex < displayText.Length)
        {
            textObject.text += displayText[currentCharIndex];
            currentCharIndex++;

            yield return new WaitForSeconds(delayDuration); // �����̕\���Ԋu
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �V�[���̐؂�ւ��ɕK�v�Ȗ��O���
using System.Collections;

public class NoTypeWriter : MonoBehaviour
{
    public Text textObject; // Text (Legacy) �R���|�[�l���g�ւ̎Q��
    public Text newMessageObject; // �V�������b�Z�[�W��\������ Text �R���|�[�l���g�ւ̎Q��
    public float initialDelay = 2.0f; // �{�^�������Ă���\�����n�܂�܂ł̏����ҋ@����
    public string newMessage = "�V�������b�Z�[�W"; // �\���������V�������b�Z�[�W
    public float delayDuration = 0.1f; // �����̕\���Ԋu

    private string displayText = ""; // �\������e�L�X�g
    private int currentCharIndex = 0;

    private void Start()
    {
        textObject.text = ""; // �ŏ��̓e�L�X�g����ɂ���
        newMessageObject.text = ""; // �V�����e�L�X�g����ɂ���
    }

    public void StartTyping()
    {
        displayText = "�c�ցA���c�H�@�c�ӂ���c�c�H�@���A�����Ȃ񂾁c�B�c���A���ƁI �ڂ��ɂ��ė~�������ƂƂ��c����H\n                  �i�������ԓ����ł����悤���c�j "; // �\���������e�L�X�g��ݒ�
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

        // �V�����e�L�X�g��\��
        newMessageObject.text = newMessage;

        // �V�[����؂�ւ���
        yield return new WaitForSeconds(2.0f); // 2�b�҂�
        SceneManager.LoadScene("Love success"); // ���̃V�[���̖��O�ɐ؂�ւ���V�[�������w��
    }
}

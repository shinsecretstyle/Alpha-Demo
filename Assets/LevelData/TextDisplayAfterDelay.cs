using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TextDisplayAfterDelay : MonoBehaviour
{
    public TMP_Text textObject; // TextMeshPro�̃e�L�X�g�v�f��Inspector����A�^�b�`����
    public Button button; // �{�^��UI��Inspector����A�^�b�`����
    public float delayBeforeDisplay = 2.0f; // �{�^����������Ă���e�L�X�g���\�������܂ł̒x�����ԁi�b�j
    public float textSpeed = 0.1f; // �����̕\�����x�i�ꕶ�����\�������Ԋu�A�b�j

    private string targetText = "This is the target text."; // �\���������e�L�X�g
    private int currentIndex = 0;
    private bool isDisplayingText = false;

    private void Start()
    {
        // �e�L�X�g�v�f�����������Ĕ�\���ɂ���
        textObject.text = "";
        textObject.gameObject.SetActive(false);

        // �{�^���̃N���b�N�C�x���g��StartTextDisplay���\�b�h���֘A�t����
        button.onClick.AddListener(StartTextDisplay);
    }

    private void Update()
    {
        // �e�L�X�g���\�������܂��S�Ă̕������\������Ă��Ȃ��ꍇ�A���̕�����\������
        if (isDisplayingText && currentIndex < targetText.Length)
        {
            textObject.text += targetText[currentIndex];
            currentIndex++;
            StartCoroutine(DisplayNextCharacter());
        }
    }

    private void StartTextDisplay()
    {
        // �e�L�X�g�\����x�������ĊJ�n����
        StartCoroutine(StartDisplayAfterDelay());
    }

    private IEnumerator StartDisplayAfterDelay()
    {
        // �w�肵���x�����Ԃ����ҋ@���Ă���e�L�X�g�\�����J�n����
        yield return new WaitForSeconds(delayBeforeDisplay);

        // �e�L�X�g��\���\�ɂ��A������
        textObject.gameObject.SetActive(true);
        currentIndex = 0;
        textObject.text = "";
        isDisplayingText = true;

        // �ŏ��̕�����\�����A���̌�̕�����\������R���[�`�����J�n
        StartCoroutine(DisplayNextCharacter());
    }

    private IEnumerator DisplayNextCharacter()
    {
        // �w�肵���e�L�X�g�\�����x�����ҋ@���Ă��玟�̕�����\������
        yield return new WaitForSeconds(textSpeed);

        if (currentIndex < targetText.Length)
        {
            // �܂��\�����ׂ��������c���Ă���ꍇ�A���̕�����\��
            StartCoroutine(DisplayNextCharacter());
        }
        else
        {
            // ���ׂĂ̕������\�����ꂽ��\���I��
            isDisplayingText = false;
        }
    }
}

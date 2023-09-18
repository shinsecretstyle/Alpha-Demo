using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextDisplayAfterDelay : MonoBehaviour
{
    public Text textObject; // �e�L�X�gUI��Inspector����A�^�b�`����
    public Button button; // �{�^��UI��Inspector����A�^�b�`����
    public string targetText = "This is the target text."; // �\���������e�L�X�g

    private bool isDisplayingText = false;

    private void Start()
    {
        textObject.text = ""; // �e�L�X�g��������
        textObject.gameObject.SetActive(false); // �e�L�X�g���\���ɂ���

        button.onClick.AddListener(StartTextDisplay);
    }

    private void StartTextDisplay()
    {
        StartCoroutine(DisplayTextAfterDelay());
    }

    private IEnumerator DisplayTextAfterDelay()
    {
        yield return new WaitForSeconds(2.0f); // 2�b�҂�

        textObject.gameObject.SetActive(true); // �e�L�X�g��\��
        textObject.text = ""; // �e�L�X�g�v�f��������
        isDisplayingText = true;

        foreach (char character in targetText)
        {
            if (!isDisplayingText)
            {
                break; // �{�^�����ēx�����ꂽ�璆�f
            }

            textObject.text += character;
            yield return new WaitForSeconds(0.1f); // 0.1�b���ƂɈꕶ���\��
        }

        isDisplayingText = false;
    }

   
}

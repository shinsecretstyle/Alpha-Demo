using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAppearance : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Button buttonToTrigger;
    public float characterAppearDelay = 0.1f; // �ꕶ�����\�������x������

    private string fullText;
    private int currentCharacterIndex;
    private float timeUntilNextCharacter;

    private bool isAppearing = false;

    private void Start()
    {
        fullText = textMeshPro.text;
        textMeshPro.text = ""; // �ŏ��̓e�L�X�g����ɂ���
        currentCharacterIndex = 0;
        timeUntilNextCharacter = characterAppearDelay;

        // �{�^���������ꂽ�Ƃ��̃C�x���g��o�^
        if (buttonToTrigger != null)
        {
            buttonToTrigger.onClick.AddListener(StartTextAppearance);
        }
    }

    private void Update()
    {
        if (isAppearing)
        {
            // ���̕����̕\�����Ԃ��J�E���g�_�E��
            timeUntilNextCharacter -= Time.deltaTime;

            if (timeUntilNextCharacter <= 0f)
            {
                // ���̕�����\��
                textMeshPro.text += fullText[currentCharacterIndex];
                currentCharacterIndex++;

                // �S�Ă̕�����\���������~
                if (currentCharacterIndex >= fullText.Length)
                {
                    isAppearing = false;
                }

                // ���̕����̕\�����Ԃ����Z�b�g
                timeUntilNextCharacter = characterAppearDelay;
            }
        }
    }

    private void StartTextAppearance()
    {
        // �{�^���������ꂽ�Ƃ��A�e�L�X�g�\�����J�n
        isAppearing = true;
    }
}

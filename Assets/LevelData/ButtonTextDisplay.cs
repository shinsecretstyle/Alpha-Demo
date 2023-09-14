using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ButtonTextDisplay : MonoBehaviour
{
    public Button button;           // �{�^�����A�^�b�`����ϐ�
    public Text textToDisplay;      // �\������e�L�X�g���A�^�b�`����ϐ�
    public string displayText;      // �\������e�L�X�g���e
    public GameObject newImage;     // �ʂ̉摜��\�����邽�߂� GameObject
    public InputAction moveAction;  // �Z���N�g�ړ��̃A�N�V����
    public InputAction pressAction; // �{�^���������A�N�V����

    private bool textDisplayed;     // �e�L�X�g���\�����ꂽ���ǂ����̃t���O

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
        // �{�^�����N���b�N���ꂽ��e�L�X�g��\��
        button.onClick.AddListener(ShowText);
        button.Select(); // �{�^���������I����Ԃɂ���
    }

    private void Update()
    {
        // �Z���N�g�ړ��̃A�N�V�������Ď����A�ړ������ɍ��킹�ă{�^����I��
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

        // �{�^���������A�N�V�������Ď����A�{�^��������
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

            // �{�^�����\���ɂ���
            button.gameObject.SetActive(false);

            // �V�����摜��\��
            newImage.SetActive(true);
        }
    }

    private void SelectButtonUp()
    {
        // ������̃Z���N�g�ړ�
        Selectable previous = button.FindSelectableOnUp();
        if (previous != null)
        {
            previous.Select();
        }
    }

    private void SelectButtonDown()
    {
        // �������̃Z���N�g�ړ�
        Selectable next = button.FindSelectableOnDown();
        if (next != null)
        {
            next.Select();
        }
    }

    private void PressButton()
    {
        // �{�^���������A�N�V�������g���K�[���ꂽ�Ƃ��̏����������ɒǉ�
    }
}

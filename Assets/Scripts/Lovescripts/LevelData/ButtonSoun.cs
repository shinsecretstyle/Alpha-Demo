using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, ISelectHandler
{
    public AudioClip selectSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("YourAudioSourceGameObject").GetComponent<AudioSource>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        // �{�^�����Z���N�g���ꂽ�ۂɉ����Đ�
        if (audioSource != null && selectSound != null)
        {
            audioSource.PlayOneShot(selectSound);
        }
    }

    // �{�^�����N���b�N���ꂽ�ۂɌĂяo����郁�\�b�h��ǉ����邱�Ƃ��ł��܂�
    public void OnButtonClick()
    {
        // �{�^�����N���b�N���ꂽ�ۂɉ����Đ�
        if (audioSource != null && selectSound != null)
        {
            audioSource.PlayOneShot(selectSound);
        }

        // �����Ƀ{�^�����N���b�N���ꂽ�ۂ̏�����ǉ����܂�
    }
}

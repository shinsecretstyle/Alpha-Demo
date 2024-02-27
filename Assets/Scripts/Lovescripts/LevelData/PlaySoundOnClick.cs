using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioClip soundToPlay; // �炵���������t�@�C����Inspector����ݒ�
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource���A�^�b�`����Ă��Ȃ��ꍇ�A�{�^���ɐV����AudioSource��ǉ�
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    private void PlaySound()
    {
        // �{�^�����N���b�N���ꂽ�Ƃ��ɉ����Đ�
        if (soundToPlay != null && audioSource != null)
        {
            audioSource.clip = soundToPlay;
            audioSource.Play();
        }
    }
}
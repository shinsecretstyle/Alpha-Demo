using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioClip soundToPlay; // 鳴らしたい音声ファイルをInspectorから設定
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSourceがアタッチされていない場合、ボタンに新しいAudioSourceを追加
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
        // ボタンがクリックされたときに音を再生
        if (soundToPlay != null && audioSource != null)
        {
            audioSource.clip = soundToPlay;
            audioSource.Play();
        }
    }
}
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
        // ボタンがセレクトされた際に音を再生
        if (audioSource != null && selectSound != null)
        {
            audioSource.PlayOneShot(selectSound);
        }
    }

    // ボタンがクリックされた際に呼び出されるメソッドを追加することもできます
    public void OnButtonClick()
    {
        // ボタンがクリックされた際に音を再生
        if (audioSource != null && selectSound != null)
        {
            audioSource.PlayOneShot(selectSound);
        }

        // ここにボタンがクリックされた際の処理を追加します
    }
}

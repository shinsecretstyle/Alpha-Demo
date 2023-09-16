using UnityEngine;
using UnityEngine.UI;

public class FadeOutMultipleImagesOnClick : MonoBehaviour
{
    public Image[] imagesToFade; // �t�F�[�h�A�E�g�������������̉摜��Inspector����ݒ�
    public float fadeDuration = 1.0f; // �t�F�[�h�A�E�g�ɂ����鎞�ԁi�b�j

    private Button button;
    private float fadeTimer = 0.0f;
    private float[] startAlphas;

    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(StartFadeOut);
        }

        startAlphas = new float[imagesToFade.Length];
        for (int i = 0; i < imagesToFade.Length; i++)
        {
            startAlphas[i] = imagesToFade[i].color.a;
        }
    }

    private void Update()
    {
        if (fadeTimer > 0)
        {
            fadeTimer += Time.deltaTime;
            float t = Mathf.Clamp01(fadeTimer / fadeDuration);

            foreach (var image in imagesToFade)
            {
                Color color = image.color;
                color.a = Mathf.Lerp(startAlphas[0], 0f, t); // �ŏ��̃A���t�@�l���珙�X��0�ɋ߂Â���
                image.color = color;
            }

            if (fadeTimer >= fadeDuration)
            {
                foreach (var image in imagesToFade)
                {
                    image.gameObject.SetActive(false);
                }
                fadeTimer = 0.0f;
            }
        }
    }

    private void StartFadeOut()
    {
        fadeTimer = 0.01f; // �t�F�[�h�A�E�g���J�n���邽�߂ɂ킸���Ɏ��Ԃ�ݒ�
    }
}

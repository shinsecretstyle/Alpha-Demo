using UnityEngine;
using UnityEngine.UI;

public class FadeOutMultipleImagesOnClick : MonoBehaviour
{
    public Image[] imagesToFade; // フェードアウトさせたい複数の画像をInspectorから設定
    public float fadeDuration = 1.0f; // フェードアウトにかける時間（秒）

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
                color.a = Mathf.Lerp(startAlphas[0], 0f, t); // 最初のアルファ値から徐々に0に近づける
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
        fadeTimer = 0.01f; // フェードアウトを開始するためにわずかに時間を設定
    }
}

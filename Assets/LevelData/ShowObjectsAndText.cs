using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections; // IEnumeratorを含む名前空間

public class ShowObjectsAndText : MonoBehaviour
{
    public GameObject imageToShow;
    public TextMeshProUGUI textToShow;
    public GameObject panelToShow;
    public float fadeInSpeed = 0.5f; // フェードイン速度を調整するパラメータ

    private bool objectsFaded = false;
    private float currentAlpha = 0f; // アルファ値を管理するための変数

    void Start()
    {
        // 画像、テキスト、パネルを非表示にする
        SetAlpha(imageToShow, 0f);
        SetAlpha(textToShow.gameObject, 0f);
        SetAlpha(panelToShow, 0f);
    }

    void Update()
    {
        if (!objectsFaded)
        {
            // ObjectFadeスクリプトを持つGameObjectが存在しない場合、
            // 画像、テキスト、パネルを表示する
            if (GameObject.FindObjectOfType<ObjectFade>() == null)
            {
                objectsFaded = true;

                if (imageToShow != null)
                {
                    StartCoroutine(FadeInObject(imageToShow));
                }

                if (textToShow != null)
                {
                    StartCoroutine(FadeInObject(textToShow.gameObject));
                }

                if (panelToShow != null)
                {
                    StartCoroutine(FadeInObject(panelToShow));
                }
            }
        }
    }

    // オブジェクトを徐々にフェードインするコルーチン
    IEnumerator FadeInObject(GameObject obj)
    {
        currentAlpha = 0f;

        while (currentAlpha < 1f)
        {
            currentAlpha += fadeInSpeed * Time.deltaTime;
            SetAlpha(obj, currentAlpha);
            yield return null;
        }
    }

    // ゲームオブジェクトのアルファ値を設定するメソッド
    void SetAlpha(GameObject obj, float alpha)
    {
        if (obj == null) return;

        if (obj.TryGetComponent<Renderer>(out Renderer renderer))
        {
            Color objColor = renderer.material.color;
            objColor.a = Mathf.Clamp01(alpha);
            renderer.material.color = objColor;
        }
        else if (obj.TryGetComponent<CanvasRenderer>(out CanvasRenderer canvasRenderer))
        {
            Color objColor = canvasRenderer.GetColor();
            objColor.a = Mathf.Clamp01(alpha);
            canvasRenderer.SetColor(objColor);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ShowObjects : MonoBehaviour
{
    public GameObject imageToShow;
    public GameObject panelToShow;
    public float fadeInSpeed = 0.5f; // フェードイン速度を調整するパラメータ

    private bool objectsFaded = false;
    private float currentAlpha = 0f; // アルファ値を管理するための変数

    void Start()
    {
        // 画像は非表示、パネルは表示しないよう初期化
        SetAlpha(imageToShow, 0f);
        SetAlpha(panelToShow, 0f); // パネルを初期状態で非表示
    }

    void Update()
    {
        if (!objectsFaded)
        {
            // ObjectFadeスクリプトを持つGameObjectが存在しない場合、
            // 画像、パネルを表示する
            if (GameObject.FindObjectOfType<ObjectFade>() == null)
            {
                objectsFaded = true;

                if (imageToShow != null)
                {
                    StartCoroutine(FadeInObject(imageToShow));
                }

                if (panelToShow != null)
                {
                    panelToShow.SetActive(true); // パネルを表示
                    StartCoroutine(FadeInObject(panelToShow)); // パネルをフェードイン
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
    public void OnButtonClick()
    {
        if (!objectsFaded)
        {
            objectsFaded = true;

            if (imageToShow != null)
            {
                StartCoroutine(FadeInObject(imageToShow));
            }

            if (panelToShow != null)
            {
                panelToShow.SetActive(true); // パネルを表示
                StartCoroutine(FadeInObject(panelToShow)); // パネルをフェードイン
            }
        }
    }
}

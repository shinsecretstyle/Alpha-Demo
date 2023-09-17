using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ObjectFade : MonoBehaviour
{
    public List<GameObject> objectsToFade; // フェードアウトさせるGameObjectのリスト
    public float fadeSpeed = 0.5f;
    private List<float> currentAlphas = new List<float>();
    private bool fadeStarted = false;

    void Start()
    {
        // 初期の透明度を設定
        foreach (GameObject obj in objectsToFade)
        {
            currentAlphas.Add(1.0f);
            SetObjectAlpha(obj, 1.0f);
        }
    }

    void Update()
    {
        // ボタンがクリックされたら透明度を減少させる
        if (!fadeStarted)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame || (Gamepad.current != null && Gamepad.current.aButton.wasPressedThisFrame))
            {
                fadeStarted = true;
            }
        }

        if (fadeStarted)
        {
            for (int i = 0; i < objectsToFade.Count; i++)
            {
                GameObject obj = objectsToFade[i];
                if (obj != null)
                {
                    currentAlphas[i] -= fadeSpeed * Time.deltaTime;
                    SetObjectAlpha(obj, currentAlphas[i]);

                    if (currentAlphas[i] <= 0f)
                    {
                        objectsToFade.RemoveAt(i);
                        currentAlphas.RemoveAt(i);
                        Destroy(obj);
                        i--;
                    }
                }
                else
                {
                    objectsToFade.RemoveAt(i);
                    currentAlphas.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    void SetObjectAlpha(GameObject obj, float alpha)
    {
        // GameObjectの透明度を設定
        Color objectColor = obj.GetComponent<Renderer>().material.color;
        objectColor.a = Mathf.Clamp01(alpha);
        obj.GetComponent<Renderer>().material.color = objectColor;
    }
}

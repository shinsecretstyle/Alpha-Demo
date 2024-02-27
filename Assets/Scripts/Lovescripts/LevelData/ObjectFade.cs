using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectFade : MonoBehaviour
{
    public List<GameObject> objectsToFade; // �t�F�[�h�A�E�g�̃��X�g
    public float fadeSpeed = 0.5f;
    private List<float> currentAlphas = new List<float>();
    private bool fadeStarted = false;

    void Start()
    {
       
        foreach (GameObject obj in objectsToFade)
        {
            currentAlphas.Add(1.0f);
            SetObjectAlpha(obj, 1.0f);
        }
    }

    public void StartFade()
    {
        fadeStarted = true;
    }

    void Update()
    {
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
        // GameObject�̓����x��ݒ�
        Color objectColor = obj.GetComponent<Renderer>().material.color;
        objectColor.a = Mathf.Clamp01(alpha);
        obj.GetComponent<Renderer>().material.color = objectColor;
    }
}
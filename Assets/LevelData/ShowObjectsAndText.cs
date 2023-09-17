using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections; // IEnumerator���܂ޖ��O���

public class ShowObjectsAndText : MonoBehaviour
{
    public GameObject imageToShow;
    public TextMeshProUGUI textToShow;
    public GameObject panelToShow;
    public float fadeInSpeed = 0.5f; // �t�F�[�h�C�����x�𒲐�����p�����[�^

    private bool objectsFaded = false;
    private float currentAlpha = 0f; // �A���t�@�l���Ǘ����邽�߂̕ϐ�

    void Start()
    {
        // �摜�A�e�L�X�g�A�p�l�����\���ɂ���
        SetAlpha(imageToShow, 0f);
        SetAlpha(textToShow.gameObject, 0f);
        SetAlpha(panelToShow, 0f);
    }

    void Update()
    {
        if (!objectsFaded)
        {
            // ObjectFade�X�N���v�g������GameObject�����݂��Ȃ��ꍇ�A
            // �摜�A�e�L�X�g�A�p�l����\������
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

    // �I�u�W�F�N�g�����X�Ƀt�F�[�h�C������R���[�`��
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

    // �Q�[���I�u�W�F�N�g�̃A���t�@�l��ݒ肷�郁�\�b�h
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

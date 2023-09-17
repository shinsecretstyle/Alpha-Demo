using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections; // IEnumerator���܂ޖ��O���

public class ShowImageAndText : MonoBehaviour
{
    public GameObject imageToShow;
    public TextMeshProUGUI textToShow;
    public float fadeInSpeed = 0.5f; // �t�F�[�h�C�����x�𒲐�����p�����[�^

    private bool objectsFaded = false;

    private float currentAlpha = 0f; // �A���t�@�l���Ǘ����邽�߂̕ϐ�

    void Start()
    {
        // �摜�ƃe�L�X�g���\���ɂ���
        if (imageToShow != null)
        {
            SetAlpha(imageToShow, 0f);
        }

        if (textToShow != null)
        {
            SetAlpha(textToShow.gameObject, 0f);
        }
    }

    void Update()
    {
        if (!objectsFaded)
        {
            // ObjectFade�X�N���v�g������GameObject�����݂��Ȃ��ꍇ�A
            // �摜�ƃe�L�X�g��\������
            if (GameObject.FindObjectOfType<ObjectFade>() == null)
            {
                objectsFaded = true;

                if (imageToShow != null)
                {
                    StartCoroutine(FadeInObject(imageToShow));
                }

                if (textToShow != null)
                {
                    StartCoroutine(FadeInText(textToShow));
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

    // �e�L�X�g�����X�Ƀt�F�[�h�C������R���[�`��
    IEnumerator FadeInText(TextMeshProUGUI text)
    {
        currentAlpha = 0f;

        while (currentAlpha < 1f)
        {
            currentAlpha += fadeInSpeed * Time.deltaTime;
            SetAlpha(text.gameObject, currentAlpha);
            yield return null;
        }
    }

    // �Q�[���I�u�W�F�N�g�̃A���t�@�l��ݒ肷�郁�\�b�h
    void SetAlpha(GameObject obj, float alpha)
    {
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

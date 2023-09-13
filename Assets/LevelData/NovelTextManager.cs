using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class NovelTextManager : MonoBehaviour
{
    public Text novelText; //�\���p�e�L�X�g
    public GameObject nextBtn; //���{�^��
    public AudioSource charSE; //1�������̌��ʉ�
    public string[] sentences; //�\�����������͂̔z��
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplaySentence()); //��������J�n
    }

    // Update is called once per frame
    void Update()
    {
        if (novelText.text == sentences[i]) //���͂�����������A�{�^����\��
        {
            nextBtn.SetActive(true);
            if (i == (sentences.Length - 1)) //����ɍŌ�̕��͂Ȃ�{�^����\��
            {
                nextBtn.SetActive(false);
            }

        }
        else
        {
            nextBtn.SetActive(false);
        }

    }
    IEnumerator DisplaySentence()
    {
        foreach (char x in sentences[i].ToCharArray()) //�`.ToCharArray()�̓e�L�X�g1�������̔z��
        {
            novelText.text += x; //1�����ǉ�
            charSE.Play(); //���ʉ��Đ�
            yield return new WaitForSeconds(0.1f); //0.1�b�Ԋu
        }
    }
    public void OnClickNext()
    {
        if (i < sentences.Length - 1) //�Ō�̕��͂łȂ��Ȃ�
        {
            i++;
            novelText.text = ""; //���݂̕��͂𔒎���
            StartCoroutine(DisplaySentence()); //���̕�������J�n
        }
    }
}
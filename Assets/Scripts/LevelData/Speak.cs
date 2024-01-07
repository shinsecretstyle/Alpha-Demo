using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speak : MonoBehaviour
{
    private string talks = "�� �� �� �� �A �� �� �� �� �� �V �C �� �� �B";
    private string[] words;
    public Text textLabel;
    public AudioClip sound;

    private void Update()
    {
        // �����P�L�[�������Ɖ�b�X�^�[�g
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Dialogue());
        }
    }

    // �R���[�`�����g���āA�P�������ƕ\������B
    IEnumerator Dialogue()
    {
        // ���p�X�y�[�X�ŕ����𕪊�����B
        words = talks.Split(' ');

        foreach (var word in words)
        {
            // 0.1�b���݂łP�������\������B
            textLabel.text = textLabel.text + word;
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
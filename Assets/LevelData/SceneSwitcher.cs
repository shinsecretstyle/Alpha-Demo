using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // �V�[�������w�肷��ϐ�
    public string targetSceneName;

    void Update()
    {
        // �����ŃG���^�[�L�[�܂��̓Q�[���p�b�h��A�{�^���̓��͂��Ď�����R�[�h��ǉ��ł��܂�
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Submit"))
        {
            // �V�[����؂�ւ���
            SwitchToTargetScene();
        }
    }

    public void SwitchToTargetScene()
    {
        // �V�[����؂�ւ���
        SceneManager.LoadScene(targetSceneName);
    }
}

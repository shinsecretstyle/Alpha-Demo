using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // シーン名を指定する変数
    public string targetSceneName;

    void Update()
    {
        // ここでエンターキーまたはゲームパッドのAボタンの入力を監視するコードを追加できます
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Submit"))
        {
            // シーンを切り替える
            SwitchToTargetScene();
        }
    }

    public void SwitchToTargetScene()
    {
        // シーンを切り替える
        SceneManager.LoadScene(targetSceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject FadeOut;

    public Transform FadeOutPoint1;
    public Transform FadeOutPoint2;
    public Transform FadeOutPoint3;

    public static int GameClear = 0;

    float t = 0f;
    float t2 = 0f;

    public string scene;
    private bool isFading = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameClear == 1)
        {
            if (!isFading)
            {
                t2 += Time.deltaTime;
                if (t2 > 2f)
                {
                    Instantiate(FadeOut, FadeOutPoint1.transform);
                    Instantiate(FadeOut, FadeOutPoint2.transform);
                    Instantiate(FadeOut, FadeOutPoint3.transform);
                    isFading = true;
                }
            }
            t += Time.deltaTime;
            if (t > 6f)
            {
                SceneManager.LoadScene("Lovetime"+scene);
            }
        }
    }
}

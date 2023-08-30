using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject FadeOut;

    public Transform FadeOutPoint;
    
    public static int GameClear = 0;
    public float t= 0f;

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
                Instantiate(FadeOut, FadeOutPoint.transform);
                Instantiate(FadeOut, FadeOutPoint.transform);
                isFading = true;
            }
            t += Time.deltaTime;
            if (t > 4f)
            {
                SceneManager.LoadScene("Lovetime");
            }
        }
    }
}

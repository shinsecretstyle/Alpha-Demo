using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private int id;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    public Sprite Image6;

    private float timer;
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        id = 1;
        timer = 600f;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("Title");
        }
        if (id == 1)
        {
            theSR.sprite = Image1;
        }
        if (id == 2)
        {
            theSR.sprite = Image2;
        }
        if (id == 3)
        {
            theSR.sprite = Image3;
        }
        if (id == 4)
        {
            theSR.sprite = Image4;
        }
        if (id == 5)
        {
            theSR.sprite = Image5;
        }
        if (id == 6)
        {
            theSR.sprite = Image6;
        }
        if (id == 7)
        {
            SceneManager.LoadScene("B1W1");
        }

    }
    private void OnNextPage()
    {
        id++;
    }
    private void OnSkip()
    {
        SceneManager.LoadScene("B1W1");
        
    }
}

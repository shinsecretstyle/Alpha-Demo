using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    public Slider HpSlider;

    int MaxHP;

    public static int HP;

    public int h;
    // Start is called before the first frame update
    void Start()
    {
        HpSlider.value = 1;

        MaxHP = 100;

        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HpSlider.value = (float)HP / (float)MaxHP;
        h = HP;

        if (HP < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

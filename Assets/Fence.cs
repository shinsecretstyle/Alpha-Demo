using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fence : MonoBehaviour
{
    public Slider HpSlider;

     int MaxHP;
    public static int HP;

    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;

    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        HpSlider.value = 1;
        MaxHP = 7;
        HP = 7;
        theSR = GetComponent<SpriteRenderer>();
        theSR.sprite = Image1;
    }

    // Update is called once per frame
    void Update()
    {
        HpSlider.value = (float)HP / (float)MaxHP;

        if (HpSlider.value < 0.6) { 
            theSR.sprite = Image2;
        }
        if (HpSlider.value == 0)
        {
            theSR.sprite = Image3;
        }
    }
}

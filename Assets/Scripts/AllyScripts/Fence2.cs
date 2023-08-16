using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fence2 : MonoBehaviour
{
    public Slider HpSlider;

    int MaxHP;
    public static int HP;

    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;

    private SpriteRenderer theSR;

    public static int ATK = Fence1.ATK;
    // Start is called before the first frame update
    void Start()
    {
        HpSlider.value = 1;
        MaxHP = 35;
        HP = 35;
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
            gameObject.GetComponent<Collider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            
        }
    }
}

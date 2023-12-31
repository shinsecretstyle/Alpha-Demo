using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuffController : MonoBehaviour
{
    public Transform a;
    //Buff
    public static bool KingsPower = false;//王威発揚  与ダメージを30％上昇
    //public GameObject k;

    public static bool KingsPowerPlus = false;//王威発揚+  与ダメージを40％上昇

    public static bool PraiseOfPain = false;//痛苦礼讃  5コンボ毎に非常に強力な追撃を発動(威力は通常攻撃の6倍)

    public static bool BlatantMalice = false;//陶然たる害意  ノーツを2個消す毎に強力な追撃を発動(威力は通常攻撃の2倍)

    public static bool ChildishEmbrace = false;//児戯じみた抱擁 ノーツを5個消す毎にとても強力な追撃を発動(威力は通常攻撃の4倍)

    public static bool CuteAggression = false;//キュートアグレッション  通常攻撃が2連続で発動する

    public static bool OutlineCollapse = false;//輪郭潰崩  与ダメージの３０％のダメージを５秒間継続して与える


    public GameObject CanvasPlus;

    public float timer = 3f;

    public bool CanTimer = false;

    //Debuff


    // Start is called before the first frame update
    void Start()
    {
        
        //Instantiate(k, a.position, new Quaternion(0f, 0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (CanTimer) {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            SceneManager.LoadScene("B1W2");
        }
    }
    public void setKingsPower()
    {
        KingsPower = true;
        SceneManager.LoadScene("Buff2");
    }
    public void setCuteAggression()
    {
        CuteAggression = true;
        SceneManager.LoadScene("Buff2");
    }
    public void setOutlineCollapse()
    {
        OutlineCollapse = true;
        SceneManager.LoadScene("Buff2");
    }
    public void setPraiseOfPain()
    {
        PraiseOfPain = true;
        Instantiate(CanvasPlus);
        CanTimer = true;
        //SceneManager.LoadScene("B1W2");
    }
    public void setBlatantMalice()
    {
        BlatantMalice = true;
        Instantiate(CanvasPlus);
        CanTimer = true;
        //SceneManager.LoadScene("B1W2");
    }
    public void setChildishEmbrace()
    {
        ChildishEmbrace = true;
        Instantiate(CanvasPlus);
        CanTimer = true;
        //SceneManager.LoadScene("B1W2");
    }
    public static void Resetall()
    {
        KingsPower = false;
        CuteAggression = false;
        OutlineCollapse = false;
        PraiseOfPain = false;
        BlatantMalice= false;
        ChildishEmbrace = false;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuffController2 : MonoBehaviour
{
    public Transform a;
    //Buff
    public static bool KingsPower = false;//���Д��g  �^�_���[�W��30���㏸
    //public GameObject k;

    public static bool KingsPowerPlus = false;//���Д��g+  �^�_���[�W��40���㏸

    public static bool PraiseOfPain = false;//�ɋ��]  5�R���{���ɔ��ɋ��͂Ȓǌ��𔭓�(�З͂͒ʏ�U����6�{)

    public static bool BlatantMalice = false;//���R����Q��  �m�[�c��2�������ɋ��͂Ȓǌ��𔭓�(�З͂͒ʏ�U����2�{)

    public static bool ChildishEmbrace = false;//���Y���݂����i �m�[�c��5�������ɂƂĂ����͂Ȓǌ��𔭓�(�З͂͒ʏ�U����4�{)

    public static bool CuteAggression = false;//�L���[�g�A�O���b�V����  �ʏ�U����2�A���Ŕ�������

    public static bool OutlineCollapse = false;//�֊s�ו�  �^�_���[�W�̂R�O���̃_���[�W���T�b�Ԍp�����ė^����


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
        if (CanTimer)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            SceneManager.LoadScene("B1W3");
        }
    }
    public void setKingsPower()
    {
        BuffController.KingsPower = true;
        SceneManager.LoadScene("Buff4");
    }
    public void setCuteAggression()
    {
        BuffController.CuteAggression = true;
        SceneManager.LoadScene("Buff4");
    }
    public void setOutlineCollapse()
    {
        BuffController.OutlineCollapse = true;
        SceneManager.LoadScene("Buff4");
    }
    public void setPraiseOfPain()
    {
        BuffController.PraiseOfPain = true;
        Instantiate(CanvasPlus);
        CanTimer = true;
        //SceneManager.LoadScene("B1W2");
    }
    public void setBlatantMalice()
    {
        BuffController.BlatantMalice = true;
        Instantiate(CanvasPlus);
        CanTimer = true;
        //SceneManager.LoadScene("B1W2");
    }
    public void setChildishEmbrace()
    {
        BuffController.ChildishEmbrace = true;
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
        BlatantMalice = false;
        ChildishEmbrace = false;
    }



}
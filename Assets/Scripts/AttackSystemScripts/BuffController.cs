using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    public Transform a;
    //Buff
    public static bool KingsPower = false;//���Д��g  �^�_���[�W��30���㏸
    public GameObject k;

    public static bool KingsPowerPlus = false;//���Д��g+  �^�_���[�W��40���㏸

    public static bool PraiseOfPain = false;//�ɋ��]  5�R���{���ɔ��ɋ��͂Ȓǌ��𔭓�(�З͂͒ʏ�U����6�{)

    public static bool blatantMalice = false;//���R����Q��  �m�[�c��2�������ɋ��͂Ȓǌ��𔭓�(�З͂͒ʏ�U����2�{)

    public static bool ChildishEmbrace = false;//���Y���݂����i �m�[�c��5�������ɂƂĂ����͂Ȓǌ��𔭓�(�З͂͒ʏ�U����4�{)

    public static bool CuteAggression = false;//�L���[�g�A�O���b�V����  �ʏ�U����2�A���Ŕ�������

    public static bool OutlineCollapse = false;//�֊s�ו�  �^�_���[�W�̂R�O���̃_���[�W���T�b�Ԍp�����ė^����

    //Debuff


    // Start is called before the first frame update
    void Start()
    {
        KingsPower = true;
        Instantiate(k, a.position, new Quaternion(0f, 0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

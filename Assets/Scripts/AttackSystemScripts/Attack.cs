using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    static int bouns = 0;
    //ATK
    public static int AttackRange1 = 4 + bouns;
    public static int AttackRange2 = 4 + bouns;
    public static int AttackRange3 = 4;
    public static int AttackRange4 = 99999;
    
    // Start is called before the first frame update
    void Start()
    {
        if (BuffController.KingsPower)
        {
            bouns = 1;
            
        }

        if(BuffController.OutlineCollapse)
        {
            bouns = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

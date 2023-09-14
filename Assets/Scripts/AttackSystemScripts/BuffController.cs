using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    public Transform a;
    //Buff
    public static bool KingsPower = false;//‰¤ˆĞ”­—g  —^ƒ_ƒ[ƒW‚ğ30“ã¸
    public GameObject k;

    public static bool KingsPowerPlus = false;//‰¤ˆĞ”­—g+  —^ƒ_ƒ[ƒW‚ğ40“ã¸

    public static bool PraiseOfPain = false;//’É‹ê—ç]  5ƒRƒ“ƒ{–ˆ‚É”ñí‚É‹­—Í‚È’ÇŒ‚‚ğ”­“®(ˆĞ—Í‚Í’ÊíUŒ‚‚Ì6”{)

    public static bool blatantMalice = false;//“©‘R‚½‚éŠQˆÓ  ƒm[ƒc‚ğ2ŒÂÁ‚·–ˆ‚É‹­—Í‚È’ÇŒ‚‚ğ”­“®(ˆĞ—Í‚Í’ÊíUŒ‚‚Ì2”{)

    public static bool ChildishEmbrace = false;//™‹Y‚¶‚İ‚½•ø—i ƒm[ƒc‚ğ5ŒÂÁ‚·–ˆ‚É‚Æ‚Ä‚à‹­—Í‚È’ÇŒ‚‚ğ”­“®(ˆĞ—Í‚Í’ÊíUŒ‚‚Ì4”{)

    public static bool CuteAggression = false;//ƒLƒ…[ƒgƒAƒOƒŒƒbƒVƒ‡ƒ“  ’ÊíUŒ‚‚ª2˜A‘±‚Å”­“®‚·‚é

    public static bool OutlineCollapse = false;//—ÖŠs’×•ö  —^ƒ_ƒ[ƒW‚Ì‚R‚O“‚Ìƒ_ƒ[ƒW‚ğ‚T•bŠÔŒp‘±‚µ‚Ä—^‚¦‚é

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

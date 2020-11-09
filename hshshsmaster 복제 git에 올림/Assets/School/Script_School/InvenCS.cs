using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenCS : MonoBehaviour
{
    //인벤아이템 : 바선생스프레이, 만원, 씽씽이, 츄르
    public Button btnB, btnM, btnS, btnC;
    //bool item_kickboard, item_cat, item_bateacher, item_elevator; 불린값 참고 !
    void Awake(){
        btnB.interactable = Ending_School.item_bateacher;
        btnM.interactable = Ending_School.item_elevator;
        btnS.interactable = Ending_School.item_kickboard;
        btnC.interactable = Ending_School.item_cat;
    }
    void Update(){
        btnB.interactable = Ending_School.item_bateacher;
        btnM.interactable = Ending_School.item_elevator;
        btnS.interactable = Ending_School.item_kickboard;
        btnC.interactable = Ending_School.item_cat;
    }
}

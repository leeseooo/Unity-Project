using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Inven여는 스크립트.
public class IvenManager : MonoBehaviour
{
    public Button btnB, btnC, btnS, btnM;
    //public static bool item_kickboard, item_cat, item_bateacher, item_elevator;
    void Awake(){
        btnB.interactable = Ending_School.item_bateacher;
        btnC.interactable = Ending_School.item_cat;
        btnS.interactable = Ending_School.item_kickboard;
        btnM.interactable = Ending_School.item_elevator;
    }
}

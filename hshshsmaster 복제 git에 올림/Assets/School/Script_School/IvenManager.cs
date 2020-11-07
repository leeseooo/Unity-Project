using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Inven여는 스크립트.
public class IvenManager : MonoBehaviour
{

    //public static bool baSpray, chuR, ssinssingE, manwon;
    public Button btnB, btnC, btnS, btnM; 
    void Awake(){
        btnB.interactable = Ending_School.baSpray;
        btnC.interacteble = Ending_School.chuR;
        btnS.interactable = Eding_School.ssinssingE;
        btnM.interactable = Ending_School.manwon;
    }
}

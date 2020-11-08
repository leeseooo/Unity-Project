using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextM1 : MonoBehaviour
{
    public Text EndingText;
    void Start()
    {
        EndingText.text = "in 내 방 엔딩 수 : " + EndArray.getRoomCnt() + "/4";
    }

    // Update is called once per frame
    void Update()
    {
        EndingText.text = "in 내 방 엔딩 수 : " + EndArray.getRoomCnt() + "/4"; 
    }
}

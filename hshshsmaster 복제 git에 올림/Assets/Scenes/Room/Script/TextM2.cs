using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextM2 : MonoBehaviour
{
    public Text EndingText;
    void Start()
    {
        EndingText.text = "in 지하철 엔딩 수 : " + EndArray.getSubCnt() + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        EndingText.text = "in 지하철 엔딩 수 : " + EndArray.getSubCnt() + "/3"; 
    }
}

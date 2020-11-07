using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//엔딩을 봤는지 여부를 저장하는 Boolean Array 관리 스크립트
public static class EndArray
{
    public static bool[] EndingArray = new bool[50];
    public static int roomCnt, subCnt, schoolCnt;
    public static void setEndingArray(int i,bool b)
    {
        EndingArray[i] = b;
    }
    public static bool getEndingArray(int i)
    {
        return EndingArray[i];
    }
}

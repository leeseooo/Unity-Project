using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//엔딩을 봤는지 여부를 저장하는 Boolean Array 관리 스크립트
public static class EndArray
{
    public static bool[] EndingArray = new bool[50];
    public static int roomCnt, subCnt, schoolCnt;
    
    //대학가 player 리스폰 위치 변수.
    public static int location;
    public static void setEndingArray(int i, bool b){
        EndingArray[i] = b;
    }
    public static bool getEndingArray(int i)
    {
        return EndingArray[i];
    }
    public static int getRoomCnt(){
        int sum =0;
        for(int i=1; i<=4; i++)
            if(EndingArray[i])
                sum++;
        return sum;
    }
    public static int getSubCnt(){
        int cnt =0;
        for(int i=5;i<=7;i++)
            if(EndingArray[i])
                cnt++;
        return cnt;
    }
    public static int getCnt(){
        int cnt =0;
        for(int i=8;i<=31;i++)
            if(EndingArray[i])
                cnt++;
        return cnt;
    }
}

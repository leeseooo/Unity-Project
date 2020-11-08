using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImg : MonoBehaviour
{
    public int EndingNumber = 0;
    public Sprite 지하철의자;
    public Sprite 지하철인파;
    public Sprite 지하철꼰대;
    public Sprite 교수;
    public Sprite 교통사고;
    public Sprite 바나나;
    public Sprite 배탈;
    public Sprite 벚꽃엔딩;
    public Sprite 부자;
    public Sprite 비둘기;
    public Sprite 사다리;
    public Sprite 코로나바이러스;
    public Sprite 킥보드;
    public Sprite 팀플;
    public Sprite 푸들;
    public Sprite 침대;
    public Sprite 피시방;
    public Sprite 휴강;
    public Sprite 버블티;
    public Sprite 돌부리;
    public Sprite 횡단보도;
    public Sprite 컴퓨터;
    public Sprite 웅덩이;
    public Sprite 고양이;
    public Sprite 명신언덕;
    public Sprite 바퀴벌레;
    public Sprite 침대점프;
    public Sprite 늦잠;
    public Sprite 등교성공;
    public Sprite 버스놓침;
    public Sprite 만원엘베;
    public Sprite 스숙오류;
    public Sprite 음식점;
    public Sprite 떡;
    public Sprite 헤딩;

    public void Change()
    {
        if (EndingNumber == 1)
            gameObject.GetComponent<Image>().sprite = 컴퓨터;
        else if (EndingNumber == 2)
            gameObject.GetComponent<Image>().sprite = 돌부리;
        else if (EndingNumber == 3)
            gameObject.GetComponent<Image>().sprite = 바나나;
        else if (EndingNumber == 4)
            gameObject.GetComponent<Image>().sprite = 침대점프;
        else if (EndingNumber == 5)
            gameObject.GetComponent<Image>().sprite = 지하철의자;

        else if (EndingNumber == 6)
            gameObject.GetComponent<Image>().sprite = 지하철인파;

        else if (EndingNumber == 7)
            gameObject.GetComponent<Image>().sprite = 지하철꼰대;

        else if (EndingNumber == 8)
            gameObject.GetComponent<Image>().sprite = 비둘기;

        else if (EndingNumber == 9)
            gameObject.GetComponent<Image>().sprite = 교수;
        else if (EndingNumber == 10)
            gameObject.GetComponent<Image>().sprite = 침대;
        else if (EndingNumber == 11)
            gameObject.GetComponent<Image>().sprite = 늦잠;
        else if (EndingNumber == 12)
            gameObject.GetComponent<Image>().sprite = 푸들;
        else if (EndingNumber == 13)
            gameObject.GetComponent<Image>().sprite = 팀플;
        else if (EndingNumber == 14)
            gameObject.GetComponent<Image>().sprite = 휴강;
        else if (EndingNumber == 15)
            gameObject.GetComponent<Image>().sprite = 교통사고;
        else if (EndingNumber == 16)
            gameObject.GetComponent<Image>().sprite = 킥보드;
        else if (EndingNumber == 17)
            gameObject.GetComponent<Image>().sprite = 헤딩;
        else if (EndingNumber == 18)
            gameObject.GetComponent<Image>().sprite = 코로나바이러스;
        else if (EndingNumber == 24)
            gameObject.GetComponent<Image>().sprite = 피시방;

        else if (EndingNumber == 25)
            gameObject.GetComponent<Image>().sprite = 벚꽃엔딩;

        else if (EndingNumber == 26)
            gameObject.GetComponent<Image>().sprite = 버블티;
        else if (EndingNumber == 27)
            gameObject.GetComponent<Image>().sprite = 횡단보도;
        else if (EndingNumber == 28)
            gameObject.GetComponent<Image>().sprite = 웅덩이;
        else if (EndingNumber == 29)
            gameObject.GetComponent<Image>().sprite = 바퀴벌레;
        else if (EndingNumber == 30)
            gameObject.GetComponent<Image>().sprite = 고양이;
        else if (EndingNumber == 31)
            gameObject.GetComponent<Image>().sprite = 음식점;
        else if (EndingNumber == 32)
            gameObject.GetComponent<Image>().sprite = 떡;
        else if (EndingNumber == 39)
            gameObject.GetComponent<Image>().sprite = 만원엘베;
        else if (EndingNumber == 40)
            gameObject.GetComponent<Image>().sprite = 등교성공;
        else if (EndingNumber == 41)
            gameObject.GetComponent<Image>().sprite = 버스놓침;
        else if (EndingNumber == 42)
            gameObject.GetComponent<Image>().sprite = 스숙오류;
        else if (EndingNumber == 43)
            gameObject.GetComponent<Image>().sprite = 배탈;
        else if (EndingNumber == 44)
            gameObject.GetComponent<Image>().sprite = 사다리;
        else if (EndingNumber == 45)
            gameObject.GetComponent<Image>().sprite = 부자;
    }
}
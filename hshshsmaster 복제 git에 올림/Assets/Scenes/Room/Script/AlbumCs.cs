using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumCs : MonoBehaviour
{
    public Button[] btns = new Button[33];
    public Sprite[] pictures = new Sprite[33];
    public GameObject img;
    void Awake(){
        for(int i =0; i<=32; i++){
            if(i==0);
            else
                btns[i].GetComponentInChildren<Text>().text = i.ToString();
            //엔딩 봤는지 검사
            if (EndArray.getEndingArray(i))
                btns[i].interactable = true;
            else
            {
                btns[i].interactable = false;
            }
        }
    }
    public void albumButton(Button mybtn){
        string numS = mybtn.GetComponentInChildren<Text>().text;
        int num = int.Parse(numS);
        if(num==33){
            num=0;
        }
        img.SetActive(true);
        img.GetComponent<Image>().sprite = pictures[num];
        //Debug.Log(num);
    }


    //public Image btnImg;

    //public GameObject parent;
    //public Button btnPrefab;
    /*void Awake()
    {
        //버튼 초기화
        for (int i=1; i<=24;i++)
        {
            //버튼 생성
            btns[i] = Instantiate(btnPrefab);
            btns[i].transform.SetParent(parent.transform, false);
            btns[i].GetComponentInChildren<Text>().text = i.ToString();

            //엔딩 봤는지 검사
            if (EndArray.getEndingArray(i))
                btns[i].interactable = true;
            else
            {
                btns[i].interactable = false;
            }
        }
        btns[1].interactable = true;
    }*/
}

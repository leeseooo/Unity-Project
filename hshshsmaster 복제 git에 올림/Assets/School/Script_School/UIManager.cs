using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text EndingText;
    public Button IvenBtn;
    public GameObject invenPanel;
    bool activeInven = false;
    public GameManager manager;
    public ChangeImg ChangeImage;
    public MakeBubble bubblegame;
    public Fadein Fade;


    //위치 관련..
    public GameObject player;
    private int location = EndArray.location;

    public void EndingScene()
    {
        manager.Img();
        Fade.fade.gameObject.SetActive(false);
    }
    void Start()
    {
        EndingText.text = "엔딩 수 : " + EndArray.schoolCnt + "/24"; //학교 엔딩 숫자로 조정. (8~31까지 총 24개)
        invenPanel.SetActive(activeInven);
        
        switch (location)
        {
            case 0: //초기위치
                player.gameObject.transform.Translate(1.5f, 0.0f, 0f);
                break;
            case 1: //버블티
                player.gameObject.transform.Translate(28.0f, 35.0f, 0f);
                //전환 후 돌아와서
                manager.talkText.text = "찝찝하게 버블이 이에 꼈다. 지각하더라도 버블은 빼야만 해.";
                ChangeImage.EndingNumber = 26;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(32, true);
                EndArray.schoolCnt++;
                break;
            case 2: //교수님.
                player.gameObject.transform.Translate(5.5f, 70.0f, 0f);
                break;
        }
    }
    void Update()
    {
        EndingText.text = "엔딩 수 : " + EndArray.getCnt() + "/24"; //학교 엔딩 숫자로 조정.
    }
    public void clickedBackButton()
    {
        //초기화면으로
        SceneManager.LoadScene("starting");
    }
    public void InvenButton(){
        activeInven = !activeInven;
        invenPanel.SetActive(activeInven);
    }
}

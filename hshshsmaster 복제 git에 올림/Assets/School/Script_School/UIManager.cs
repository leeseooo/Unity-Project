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

    //위치 관련..
    public GameObject player;
    private int location;
    
    void Start()
    {
        EndingText.text = "엔딩 수 : " + EndArray.schoolCnt + "/20"; //학교 엔딩 숫자로 조정.
        invenPanel.SetActive(activeInven);

        location = EndArray.location;
        switch (location)
        {
            case 0: //초기위치
                player.gameObject.transform.Translate(1.5f, 0.0f, 0f);
                break;
            case 1: //버블티
                player.gameObject.transform.Translate(28.0f, 35.0f, 0f);
                break;
            case 2: //교수님.
                player.gameObject.transform.Translate(5.5f, 70.0f, 0f);
                break;
        }
    }
    void Update()
    {
        EndingText.text = "엔딩 수 : " + EndArray.schoolCnt + "/20"; //학교 엔딩 숫자로 조정.
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

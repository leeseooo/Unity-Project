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
    
    void Start()
    {
        EndingText.text = "엔딩 수 : " + EndArray.schoolCnt + "/20"; //학교 엔딩 숫자로 조정.
        invenPanel.SetActive(activeInven);
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

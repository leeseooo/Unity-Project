using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSc : MonoBehaviour
{
    public GameObject AlbumPanel;
    public GameObject creditPanel;
    public GameObject HowtoPanel;

    public GameObject AlbumImg;

    bool activeAlbum = false;
    bool activeCredit = false;
    bool activeHowto = false;

    public AudioSource audio_start;

    private void Start()
    {
        AlbumPanel.SetActive(activeAlbum);
        creditPanel.SetActive(activeCredit);
        HowtoPanel.SetActive(activeHowto);
    }

    void Awake(){
        audio_start = GetComponent<AudioSource>();
    }
    //게임 시작 버튼
    public void OnStartingButton()
    {
        audio_start.Play();
        //눈송이 방으로 씬 전환
        SceneManager.LoadScene("room");
    }
    //종료버튼
    public void OnQuitButton()
    {
        audio_start.Play();
        Application.Quit();
    }
    //앨범 창
    public void OnAlbumButton()
    {
        audio_start.Play();
        activeAlbum = !activeAlbum;
        AlbumPanel.SetActive(activeAlbum);
    }
    //크레딧 버튼
    public void OnCredit()
    {
        audio_start.Play();
        activeCredit = !activeCredit;
        creditPanel.SetActive(activeCredit);
    }
    //게임방법 창
    public void OnHowtoButton()
    {
        audio_start.Play();
        activeHowto = !activeHowto;
        HowtoPanel.SetActive(activeHowto);
    }
    //뒤로가기
    public void ClickedBack()
    {
        audio_start.Play();
        if(true)
            AlbumImg.SetActive(false);
        if (activeAlbum)
            OnAlbumButton();
        else if (activeCredit)
            OnCredit();
        else if (activeHowto)
            OnHowtoButton();
    }
}

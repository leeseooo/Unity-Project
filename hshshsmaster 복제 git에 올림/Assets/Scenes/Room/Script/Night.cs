using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Night : MonoBehaviour
{
    public GameObject NightPanel;
    private bool isNight = false;
    private float timer;
    public ChangeImg ChangeImage;
    public GameManager manager;
    public Fadein Fade;

    //문, 침대, 컴퓨터 체크... 해제
    Collider2D[] cArray = new Collider2D[3];
    public GameObject[] gArray = new GameObject[3];

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        if (Random.Range(1, 4) == 1)
        {
            isNight = true;
        }
        NightPanel.SetActive(isNight);
        for (int i = 0; i < 3; i++)
        {
            cArray[i] = gArray[i].GetComponent<Collider2D>();
            cArray[i].enabled = !isNight;
            //Debug.Log(i + "getCollider");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (isNight && timer > 5)
        {
            //포탈 사용 X
            manager.talkText.text = "앗 저녁이라니 !! 늦잠을 자버렸다~!!";
            ChangeImage.EndingNumber = 11;
            ChangeImage.Change();
            EndArray.setEndingArray(4, true);
            EndingScene_room();
            Invoke("reloadScean",4);
            //EndArray.roomCnt++;
        }
    }
    public void EndingScene_room()
    {
        manager.Img();
        transform.position = new Vector3(-1, 0, 0);
        Fade.fade.gameObject.SetActive(false);
    }

    public void reloadScean(){
        SceneManager.LoadScene("Room");
    }
}
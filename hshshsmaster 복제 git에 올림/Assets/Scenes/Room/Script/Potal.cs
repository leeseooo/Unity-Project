using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    public GameManager manager;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.talkText.text = "윗 방향키를 눌러주세요.";
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("SubwayScene");
            }
        }
    }
}
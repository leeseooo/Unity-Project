using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("윗방향키를 눌러주세요.");
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("SubwayScene");
            }
        }
    }
}
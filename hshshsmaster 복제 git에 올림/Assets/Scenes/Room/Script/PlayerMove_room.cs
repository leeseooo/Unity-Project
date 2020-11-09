using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove_room : MonoBehaviour
{
    //public GameObject NightPanel;
    //private bool isNight = false;
    public float jumpPower;
    public float maxSpeed;//속력 상한값 설정
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private int jumpCheck;
    private bool isOnbed;
    //private bool isSleeping;
    float timer = 0f;
    //float timer2 = 0f;
    GameObject scanObject;
    public GameManager manager;
    public GameObject frame;
    public Fadein Fade;
    public ChangeImg ChangeImage;

    //점프 소리
    AudioSource audio_rooms;

    //문, 침대, 컴퓨터 체크... 해제
    Collider2D[] cArray = new Collider2D[3];
    public GameObject[] gArray = new GameObject[3];

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audio_rooms = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            audio_rooms.Play();
            //침대에서 점프
            if (isOnbed)
            {
                ++jumpCheck;
                if (jumpCheck == 5)
                {
                    rigid.AddForce(new Vector2(50, 50), ForceMode2D.Impulse);
                    manager.talkText.text = "침대가 너무나도 탄력적이라 천장을 뚫고 날아가버렸다~~!!";
                    ChangeImage.EndingNumber = 4;
                    ChangeImage.Change();
                    EndingScene_room();
                    EndArray.setEndingArray(3, true);
                    EndArray.roomCnt++;
                }
            }
        }
        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite 방향전환
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3) //절댓값이 0.3보다 작으면(멈추면)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
    void FixedUpdate()
    {
        //Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h * 2, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) //Right Max Speed, 너무 빠를 때
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);//y축을 0으로 잡으면 공중에 안뜸

        /*else//sleep getlayermask 있던 부분...
            timer2 = 0f;
        Debug.DrawRay(rigid.position, Vector3.down * (1), new Color(0, 1, 0));*/
        
        //Landing Platform

        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down * (1), new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.6f)
                {
                    anim.SetBool("isJumping", false);
                    anim.SetBool("isSitting", false);
                }
            }
        }

        Debug.DrawRay(rigid.position, Vector3.right * (1), new Color(0, 1, 0));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector3.right, 1, LayerMask.GetMask("Object"));
        if (rayHit2.collider != null) //스캔한 오브젝트 저장
        {
            scanObject = rayHit2.collider.gameObject;
        }

        if (Input.GetKeyDown(KeyCode.Z) && scanObject != null) //오브젝트 스캔
        {
            manager.Action(scanObject);
            scanObject = null;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "bedCheck")
        {
            isOnbed = true;
        }
        else if (other.gameObject.tag == "door") //지하철 문이동
        {
            transform.Translate(22, 0, 0);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "bedCheck")
        {
            isOnbed = false;
            jumpCheck = 0;
            timer=0;
            anim.SetBool("isSleeping",false);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "ammoCollider")
        {
            manager.talkText.text = "고인물 화석선배잖아..마주치고 싶으면 z키를 누르자.";
        }
        else if (other.gameObject.name == "암모나이트" && Input.GetKeyDown(KeyCode.Z))
        {
            ChangeImage.EndingNumber = 7;
            ChangeImage.Change();
            manager.talkText.text = "꼰대 화석 선배를 만나 몸과 마음이 피폐해졌다..!";
            EndingScene();
            EndArray.setEndingArray(6, true);
            EndArray.subCnt++;
        }
        else if (other.gameObject.name == "bedCheck") {
            manager.talkText.text = "점프하고 싶은 침대야. z키를 꾹 누르고 있으면 잘 수 있겠어.";
        }
        else if (Input.GetKey(KeyCode.Z)&& other.gameObject.name == "bedCollider")
        {
            anim.SetBool("isSleeping", true);
            timer += Time.deltaTime;
            Debug.Log("자는중 " + timer);
            if (timer >= 10)
            {
                EndArray.setEndingArray(2, true);
                manager.talkText.text = "이불 밖은 위험해 !! 침대 밖으로 나올 생각이 없다..";
                ChangeImage.EndingNumber = 10;
                ChangeImage.Change();
                EndingScene_room();
                EndArray.roomCnt++;
                anim.SetBool("isSleeping", false);
            }
        }
        else if (other.gameObject.name == "doorCollider")
        {
            manager.talkText.text = "뒤로 돌아가려면 문앞에서 z키를 누르세요.";
        }
        else if (other.gameObject.name == "frontdoor" && Input.GetKeyDown(KeyCode.Z))
        {
            ChangeImage.EndingNumber = 6;
            ChangeImage.Change();
            manager.talkText.text = "사람이 너무 많은 곳으로 내리려다... 인파에 파묻혔다!!";
            EndingScene();
            EndArray.setEndingArray(5, true);
            EndArray.subCnt++;
        }
        else if (other.gameObject.name == "midCollider")
        {
            manager.talkText.text = "개찰구로 나가면 대학가가 나올 것 같아!";
        }
        else if (other.gameObject.name == "comCollider")
        {
            manager.talkText.text = "z키를 눌러서 컴퓨터 전원을 킬 수 있어. 게임한판ㄱㄱ?";

        }
        if (Input.GetKeyDown(KeyCode.Z) && other.gameObject.name == "com")
        {
            manager.talkText.text = "컴퓨터의 유혹에 빠져...학교에 늦어버렸다!!";
            ChangeImage.EndingNumber = 1;
            ChangeImage.Change();
            EndingScene_room();
            EndArray.setEndingArray(1, true);
            EndArray.roomCnt++;
        }
        else if (other.gameObject.name == "chairTalk2")
        {
            manager.talkText.text = "다리 아파...좀 앉았다가 가자~~!!";
            if (Input.GetKey(KeyCode.DownArrow))
            {
                timer += Time.deltaTime;
                anim.SetBool("isSitting", true);
                if (timer > 0.5)
                {
                    manager.talkText.text = "의자에 엉덩이가 붙어 학교에 지각했다..";
                    anim.SetBool("isSitting", false);
                    ChangeImage.EndingNumber = 5;
                    ChangeImage.Change();
                    EndingScene();
                    EndArray.setEndingArray(7, true);
                    EndArray.subCnt++;
                }
            }
        }
        else if (other.gameObject.name == "chairTalk")
        {
            manager.talkText.text = "아래 방향키를 누르면 앉아서 갈 수 있어.";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)&& other.gameObject.name == "chairCollider")
        {
            timer += Time.deltaTime;
            anim.SetBool("isSitting", true);
            if (timer > 0.5)
            {
                manager.talkText.text = "의자에 엉덩이가 붙어 학교에 지각했다..";
                anim.SetBool("isSitting", false);
                ChangeImage.EndingNumber = 5;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(7, true);
                EndArray.subCnt++;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)&& other.gameObject.name == "chairCollider")
        {
            timer += Time.deltaTime;
            anim.SetBool("isSitting", true);
            if (timer > 0.5)
            {
                manager.talkText.text = "의자에 엉덩이가 붙어 학교에 지각했다..";
                anim.SetBool("isSitting", false);
                ChangeImage.EndingNumber = 5;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(7, true);
                EndArray.subCnt++;
            }
        }
    }
    public void EndingScene()
    {
        manager.Img();
        Fade.fade.gameObject.SetActive(false);
    }
    public void EndingScene_room()
    {
        manager.Img();
        transform.position = new Vector3(-1, 0, 0);
        Fade.fade.gameObject.SetActive(false);
        timer = 0;
    }
}
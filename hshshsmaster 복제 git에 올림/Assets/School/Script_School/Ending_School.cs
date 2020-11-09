using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_School : MonoBehaviour
{
    GameObject scanObject;
    public GameManager manager;
    public GameObject mini_1; // 교수님과 달리기 이미지
    public GameObject mini_2; // 버블티먹기 설명 이미지

    bool minigame_teacher;
    
    //엔딩관련 변수
    bool bus,elev,bubbletea, restaurant_1, restaurant_2, restaurant_3, restaurant_4, class_1, class_2, class_3,cat_tag;
    bool kickboard,box_cat,teampler,bateacher, box_elev;

    public int restaurant_count=0;
    
    //아이템변수
    public static bool item_kickboard, item_cat, item_bateacher, item_elevator;
    
    bool item_tag; //현재 태그 상태 체크 = 태그됨 :true, 태그안됨: false
    int random;
    
    public Fadein Fade;
    public ChangeImg ChangeImage;

    public AudioSource audio;
    [SerializeField] private AudioClip [] clip;

    void Awake(){
        audio = GetComponent<AudioSource>();
    }

    //엔딩 화면 코드
    void EndingScene()
    {
        manager.Img();
        audio.clip = clip[0];
        audio.Play();
        Fade.fade.gameObject.SetActive(false);
    }

    private void Update(){

        //1. 떡집 엔딩 입력 - 해당없음

        //2. 버스 엔딩 입력
        if (bus && Input.GetKeyDown(KeyCode.Z))
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            random = Random.Range(0, 100);
            if (random == 0)
            {
                manager.talkText.text = "100분의 1의 확률로 버스타고 등교 성공";
                ChangeImage.EndingNumber = 40;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(8, true);
                //순간이동
                transform.Translate(-19.05f, 45.05f, 0);

            }
            else
            {
                manager.talkText.text = "학교까지 가는 버스를 눈앞에서 놓치고 말았다! 다음 버스는 30분 뒤...!!";
                ChangeImage.EndingNumber = 41;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(9, true);
            }
        }

        //2. 버스엔딩 + 15. 잘못내린엔딩 ** 고려해보기


        //5. 엘베 엔딩 입력 *** 수정필요
        else if (elev && Input.GetKeyDown(KeyCode.Z))
        {

            //5-1) 만원 아이템 있으면 if -> 순간이동
            if (item_elevator)
            {
                transform.Translate(15f, 27f, 0);
            }
            //5-2) 만원 아이템 없으면 else
            else
            {
                manager.talkText.text = "사람이 너무 많아 탈 수 없다! 엘레베이터를 타려면 만원 아이템을 가져와라!";
                ChangeImage.EndingNumber = 39;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(10, true);
            }
        }

        //5-2. 엘레베이터 아이템(만원)획득
        else if (box_elev && Input.GetKeyDown(KeyCode.Z))
        {
            if (item_elevator)
            {
                manager.talkText.text = "이미 아이템을 획득한 상자입니다.";
            }
            else
            {
                item_elevator = true;
                manager.talkText.text = "만원 아이템을 획득하였습니다.";
            }
            box_elev = false;
        }

        //9. 교수가 먼저 도착 (●)
        else if (class_3 && Input.GetKeyDown(KeyCode.Z))
        {
            manager.talkText.text = "이런, 교수님이 먼저 도착했잖아! 출석체크는 이미 지나가버렸다!";
            ChangeImage.EndingNumber = 9;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(11, true);
        }

        //14. 휴강(●)
        else if (class_1 && Input.GetKeyDown(KeyCode.Z))
        {
            manager.talkText.text = "오늘은 휴강이고 나는 독강러...집에 가자...";
            ChangeImage.EndingNumber = 14;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(12, true);
        }


        //16. 킥보드 획득 
        else if (kickboard && Input.GetKeyDown(KeyCode.Z))
        {
            if (item_kickboard)
            {
                manager.talkText.text = "이미 아이템을 획득한 상자입니다.";
            }
            else
            {
                item_kickboard = true;
                manager.talkText.text = "킥보드 아이템을 획득하였습니다.";
            }

            kickboard = false;
        }

        //17. 고양이 간식 회득
        else if (box_cat && Input.GetKeyDown(KeyCode.Z))
        {
            if (item_cat)
            {
                manager.talkText.text = "이미 아이템을 획득한 상자입니다.";
            }
            else
            {
                item_cat = true;
                manager.talkText.text = "고양이 간식 아이템을 획득하였습니다.";
            }
            box_cat = false;
        }

        //고양이
        else if (cat_tag && Input.GetKeyDown(KeyCode.Z))
        {
            if (item_cat)
            {
                manager.talkText.text = "교수님보다는 고양이가 훨씬 더 귀여웠다!! 고양이랑 놀다가 지각!";
                ChangeImage.EndingNumber = 30;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(13, true);
            }
            else
            {
                manager.talkText.text = "간식줘~! 3층정도 가면 찾을 수 있을거야.";
            }
            cat_tag = false;
        }

        //19. 스숙오류
        else if (class_2 && Input.GetKeyDown(KeyCode.Z))
        {
            manager.talkText.text = "전자출결 오류가 발생했다! 교수님께 말씀드렸지만 증거가 없어 결석되었다...";
            ChangeImage.EndingNumber = 42;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(14, true);
        }

        //22. 바선생약 획득
        else if (bateacher && Input.GetKeyDown(KeyCode.Z))
        {
            if (item_bateacher)
            {
                manager.talkText.text = "이미 아이템을 획득한 상자입니다.";
            }
            else
            {
                item_bateacher = true;
                manager.talkText.text = "바선생약 아이템을 획득하였습니다.";
            }

            bateacher = false;
        }

        //26. 버블티 가게 엔딩 (●) - 미니게임연결
        else if (bubbletea && Input.GetKeyDown(KeyCode.Z))
        {
            mini_2.SetActive(false);
            EndArray.location = 1;
            //씬전환 - 미니게임
            SceneManager.LoadScene("BubbleTea");
            bubbletea = false;
        }

        //28. 학교 앞 음식점 5개 이상 살펴보면 배불러서 지각
        else if (restaurant_1 && Input.GetKeyDown(KeyCode.Z))
        {
            restaurant_count++;
            manager.talkText.text = "이곳은 시금치 파스타가 맛있는 바시마시!";
            restaurant_1 = false;
        }
        else if (restaurant_2 && Input.GetKeyDown(KeyCode.Z))
        {
            restaurant_count++;
            manager.talkText.text = "와우세트 먹고 가자 !";
            restaurant_2 = false;
        }
        else if (restaurant_3 && Input.GetKeyDown(KeyCode.Z))
        {
            restaurant_count++;
            manager.talkText.text = "오늘도 사람이 많군!";
            restaurant_3 = false;
        }
        else if (restaurant_4 && Input.GetKeyDown(KeyCode.Z))
        {
            restaurant_count++;
            manager.talkText.text = "콩불먹고 볶음밥까지 먹어줘야 진정한 또가또!";
            restaurant_4 = false;
        }
        
        //28.
        if(restaurant_count == 5){
            manager.talkText.text = "학교 앞 음식점은 보기만 해도 배부르다..몸이 무거워져서 지각하고 말았다!";
            ChangeImage.EndingNumber = 31;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(15, true);
            restaurant_count = 6;
        }

        //교수님과 달리기
        if(minigame_teacher && Input.GetKeyDown(KeyCode.Z)){
                mini_1.SetActive(false);
                EndArray.location = 2;
                SceneManager.LoadScene("MiniRunGame");
                Debug.Log("교수님과 달리기 미니게임을 로드합니다.");
                minigame_teacher = false;
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1, 떡집 엔딩
        if(collision.gameObject.name == "Store3"){
            restaurant_count++;
            manager.talkText.text = "떡 향기에 홀려서 등교할 의지를 잃었다..";
            ChangeImage.EndingNumber = 32;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(16, true);
        }

        //2. 버스 기다리는 엔딩 + 입력: update()함수, bool 변수 bus
        else if(collision.gameObject.name == "Busstop"){
            bus=true;
            manager.talkText.text = "버스를 기다리시겠습니까? 기다리려면 z키를 눌러주세요.";
        }

        //3-1(바나나) ● , 3-2(돌) ●, 트랩엔딩
        else if (collision.gameObject.name == "Banana"){
            manager.talkText.text = "바나나를 밟아 언덕에서 데굴데굴 굴렀다! 다리를 다쳐 학교에 가지 못한다!";
            ChangeImage.EndingNumber = 3;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(17, true);
        }
        
        else if(collision.gameObject.name == "Stone"){
            manager.talkText.text = "돌에 걸려 데굴데굴 굴렀다! 다리를 다쳐 학교에 가지 못한다!";
            ChangeImage.EndingNumber = 2;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(18, true);
        }

        //4. 라옥화 엔딩 
        else if(collision.gameObject.name == "Store2"){
            manager.talkText.text = "\"쪼꼬야 이름이 뭐야?\" 아무 대답없는 쪼꼬를 바라보며 망부석이 되었다.";
            ChangeImage.EndingNumber = 12;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(19, true);
        }

        //5, 만원엘베 - (10000원 아이템 있으면 통과, 없으면 가져오라고..) , bool 변수 elev
        
        else if(collision.gameObject.name == "Elevator"){
            elev = true;
            manager.talkText.text = "엘레베이터를 탑승해 강의실로 이동하려면 z키를 눌러주세요.";
        }

        //5-2. 만원아이템
        else if(collision.gameObject.name == "Box_elevator"){
            box_elev = true;
            manager.talkText.text = "상자를 열려면 z키를 누르세요.";
        }

        //6. 친구만나 자체휴강

        //7. 까먹은 준비물 엔딩 **조금 더 생각
        //8. 비둘기 monster - OncollisionEnter구현
        //9. 교수가 먼저 도착 엔딩
        else if(collision.gameObject.name == "Class3"){
            class_3 = true;
        }
        //9-1. 교수님과 달리기 ? !
        else if(collision.gameObject.name == "Teacher"){
            mini_1.SetActive(true);
            manager.talkText.text = "교수님이 달리기 시합을 걸어왔다 !(계속하려면 z키)";
            minigame_teacher = true;
            // 위로 옮김 
            /*
            if(Input.GetKeyDown(KeyCode.Z)){
                mini_1.SetActive(false);
                EndArray.location = 2;
                SceneManager.LoadScene("MiniRunGame");
                Debug.Log("교수님과 달리기 미니게임을 로드합니다.");
            }
            */
        }

        //10. 부자 엔딩 (player이동 스크립트에 구현)
        //11. 입구역 엔딩 (x)
        //12. 배탈엔딩 (player이동 스크립트에 구현)
        //13. 쪽지 **고민..
        
        //13-2. 계단엔딩


        //14. 휴강 - 교실
        else if(collision.gameObject.name == "Class1"){
            class_1 = true;
        }
        
        //15. 고민..
        //16. 상자 - 킥보드 발견
        else if(collision.gameObject.name == "Box_Kickboards"){
            kickboard = true;
            manager.talkText.text = "상자를 열려면 z키를 누르세요.";
        }

        //16-1. 효창공원 도착 (▲) 킥보드 없는거 엔딩그림 안그림
        else if (collision.gameObject.name == "Hyochangpark")
        {   
            if(item_kickboard)
            {
                manager.talkText.text = " 공원에서 시간가는 줄 모르고 킥보드를 재밌게 씽씽 타다가 결국 지각하고 말았다..!";
                ChangeImage.EndingNumber = 16;
                ChangeImage.Change();
                EndingScene();
                EndArray.setEndingArray(20, true);
            }
            else{
                manager.talkText.text = "킥보드가 있으면 효창공원에서 더 재밌게 놀 수 있을 텐데..";
            }
        }

        //17. 상자 - 고양이 간식 발견
        else if(collision.gameObject.name == "Box_Cat"){
            box_cat = true;
            manager.talkText.text = "상자를 열려면 z키를 누르세요.";
        }
        // 고양이 배치
        else if(collision.gameObject.name == "Cat"){
            cat_tag = true;
            manager.talkText.text = "고양이에게 말을 걸려면 z키를 누르세요.";
        }
    
        //18. 코로나 엔딩 - 동굴 미니게임 X
        //18-2. 코로나 바이러스 엔딩 - OnCollisionEnter에 구현

        //19. 전자출결 - 교실
        else if(collision.gameObject.name == "Class2"){
            class_2 = true;
        }


        //20. 물웅덩이 (트랩)
        else if(collision.gameObject.name == "Rain"){
            manager.talkText.text = "물이 잔뜩 고여 있는 웅덩이를 밟고 말았다! 기분나빠, 집에 갈거야!";
            ChangeImage.EndingNumber = 28;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(21, true);
        }

        //21, 상자 - 팀플러 엔딩
        else if(collision.gameObject.name == "Box_Teamplayer"){
            manager.talkText.text = "ㅋㅋㅋ으로 도배한 마지막 수정본을 확인해달라고 했지만 나머지 팀원들은 문제없으니 진행하자고 한다..";
            ChangeImage.EndingNumber = 13;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(22, true);
        }

        //22. 상자 - 바선생약
        else if(collision.gameObject.name == "Box_Bateacher"){
            bateacher = true;
            manager.talkText.text = "상자를 열려면 z키를 누르세요.";
        }
        
        //23. 설문조사, 도믿맨

        //24. PC방 엔딩 ●
        else if(collision.gameObject.name == "Pcroom"){
            manager.talkText.text = "딱 한판만..진짜 딱 한판만 더 하려다가 결국 지각하고 말았다!";
            ChangeImage.EndingNumber = 24;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(23, true);
        }

        //25. 벚꽃 구경하다가 지각 ●
        else if (collision.gameObject.name == "Flower"){
            manager.talkText.text = "벚꽃보다가 학교에 가지 못했다..그치만 너무 예쁜걸?";
            ChangeImage.EndingNumber = 25;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(24, true);
        }

        //26. 버블티 가게 엔딩
        else if(collision.gameObject.name == "Bubbletea"){
            mini_2.SetActive(true);
            manager.talkText.text = "카페에 들어가려면 z키를 누르세요.";
            bubbletea = true;
            EndArray.location = 1;
        }

        //27. 교통사고 신호등 엔딩
        else if(collision.gameObject.name == "Trafficlight"){
            manager.talkText.text = "등교길에 신호등을 건너다가 그만 교통사고를 당하고 말았다! ";
            ChangeImage.EndingNumber = 15;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(25, true);
        }
        
        //28. 학교 앞 음식점 5개 이상 살펴보면 배불러서 지각(마시바시, 신내떡, 선다래, 또와또, 떡집)
        if(collision.CompareTag("Restaurant")){
            if(collision.gameObject.name == "Restaurant1")
            {
                restaurant_1 = true;
                manager.talkText.text = "바시마시에 들어가시려면 z키를 눌러주세요.";
            }
            else if(collision.gameObject.name == "Restaurant2"){
                restaurant_2 = true;
                manager.talkText.text = "신네떡에 들어가시려면 z키를 눌러주세요.";
                
            }
            else if(collision.gameObject.name == "Restaurant3"){
                restaurant_3 = true;
                manager.talkText.text = "선다레에 들어가시려면 z키를 눌러주세요.";
            }
            else if(collision.gameObject.name == "Restaurant4"){
                restaurant_4 = true;
                manager.talkText.text = "또가또에 들어가시려면 z키를 눌러주세요.";
            }
        }

        //29. 보도블럭

        //30. 사다리엔딩 (player이동 스크립트에 구현)
        //31. 호수에 빠져서 사망 **생각

        //32. ? 에 헤딩하고 엔딩
        else if(collision.gameObject.name == "Heading" || collision.gameObject.name == "Heading_b"){
            manager.talkText.text = "헤딩을 하다가 머리에 상처가 나 병원에 가버렸다..!";
            ChangeImage.EndingNumber = 17;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(26, true);
        }

        //class enter 할건지 말건지 물어보는 - Classentercollider
        else if(collision.gameObject.name == "Classentercollider"){
            manager.talkText.text = "교실에 들어가려면 z키를 누르세요.";
        }

    }

    private void onTriggerStay2D(Collider2D collision){
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //2. 버스
        if(collision.gameObject.name == "Busstop"){
            bus=false;
            manager.talkText.text = "아~아쉽다 버스타면 빨리 학교에 도착할 수 있는데~";
        }

        //5. 만원엘베
        else if(collision.gameObject.name == "Elevator"){
            elev = false;
            manager.talkText.text = "강의실에 가는 방법은 엘레베이터 뿐인데?!";
        }

        //9. 교수가 먼저 도착
        else if(collision.gameObject.name == "Class3"){
            class_3 = false;
        }

        //14. 휴강 - 교실
        else if(collision.gameObject.name == "Class1"){
            class_1 = false;
        }
        // 고양이 배치
        else if(collision.gameObject.name == "Cat"){
            cat_tag = false;
        }

        //16. 상자 - 킥보드 발견
        else if(collision.gameObject.name == "Box_Kickboards"){
            kickboard = false;
        }

        //17. 상자 - 고양이 간식 발견
        else if(collision.gameObject.name == "Box_Cat"){
            box_cat = false;
        }

        //고양이 배치
        else if(collision.gameObject.name == "Cat"){
            cat_tag = false;
        }


        //19. 전자출결 - 교실
        else if(collision.gameObject.name == "Class2"){
            class_2 = false;
        }

        //22. 상자  - 바선생약
        else if(collision.gameObject.name == "Box_Bateacher"){
            bateacher = false;
        }

        //26. 버블티 가게 엔딩
        else if(collision.gameObject.name == "Bubbletea"){
            manager.talkText.text = "카페인 안먹으면 분명 강의듣다 졸텐데..";
            bubbletea = false;
            mini_2.SetActive(false);
        }

        //학교앞음식점
        if(collision.CompareTag("Restaurant")){
            if(collision.gameObject.name == "Restaurant1")
            {
                restaurant_1 = false;
               
            }
            else if(collision.gameObject.name == "Restaurant2"){
                restaurant_2 = false;
                
                
            }
            else if(collision.gameObject.name == "Restaurant3"){
                restaurant_3 = false;
                
            }
            else if(collision.gameObject.name == "Restaurant4"){
                restaurant_4 = false;
                
            }
        }
        //교수와 달리기 엔딩
        else if(collision.gameObject.name == "Teacher"){
            minigame_teacher = false;
            mini_1.SetActive(false);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        //8. 비둘기 엔딩 ●
        if(collision.gameObject.tag == "Bird"){
            manager.talkText.text = "비둘기의 공격!! 끼약!!! (기절)";
            ChangeImage.EndingNumber = 8;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(27, true);
        }


        //18. 코로나 바이러스 몬스터
        if(collision.gameObject.tag == "Virus"){
            manager.talkText.text = "코로나 바이러스 출몰!! 사회적 거리두기 해야돼서 학교 못가겠다.";
            ChangeImage.EndingNumber = 18;
            ChangeImage.Change();
            EndingScene();
            EndArray.setEndingArray(28, true);
        }


    }
    
}
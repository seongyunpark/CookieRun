using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 2022.08.04 Mang
/// 
/// 쿠키 조종을 위한 모든것을 담을 스크립트
/// 쿠키 -> 점프, 슬라이드, 충돌, 중력 필요
/// </summary>
public class Cookie : MonoBehaviour
{
    public static Cookie Instance;

    public Image Hp;                    // 체력바가 줄어들 이미지

    public Rigidbody2D playerRigid;   // Rigidbody2D 속성 변수 생성
    public Animator CookieAni;

    [SerializeField]
    private BoxCollider2D BoxCol;        // 쿠키의 행동에 따라 콜라이더를 바꿔주기 위한 변수

    public GameObject FallenCollision;

    public Button SlideButton;

    private float MiniPortion;          // 쿠키의 체력을 회복시켜줄 변수

    public float firstJumpPower;     // 플레이어 점프 파워
    public float secondJumpPower;     // 플레이어 점프 파워

    float MaxHP;
    public float NowHp;             // 캐릭터의 현재 체력
    float prevHP;
    public int Jelly;          // 젤리먹으면 점수증가
    public int Coin;           // 코인 증가

    float MinusHPofCrash;       // 캐릭터 트랩 충돌시 줄어들 Hp 값

    int NormalJelly;            // 각 젤리, 코인들 값
    int PinkJelly;
    int YellowJelly;

    int SilverCoin;
    int SilverCoinScore;
    int GoldCoin;
    int GoldCoinScore;

    int nowJumpCount;                   // 점프를 몇번 했는지 카운팅할 변수


    //public int count;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();        // rigid 변수를 Character의 Rigidbody2D 속성으로 초기화

        CookieAni = GetComponent<Animator>();

        BoxCol = GetComponent<BoxCollider2D>();

        // Hp = GetComponent<Image>();                  // 이유를 알았다. 게임오브젝트를 변수로 만들어서 해당 오브젝트를 받고 
        // Hp = image.GetComponent<Image>();            // 이렇게 썼으면 해결 됬을 일이다...!
        // 이렇게 겟컴퍼넌트를 안써도 이미 밖에서 오브젝트를 연결을 해줬기 때문에 가능하다..!

        MaxHP = 162;
        NowHp = MaxHP;
        prevHP = NowHp;

        Jelly = 0;
        Coin = 0;

        NormalJelly = 1499;
        PinkJelly = 40555;
        YellowJelly = 58444;

        SilverCoin = 1;
        SilverCoinScore = 4666;
        GoldCoin = 100;
        GoldCoinScore = 48888;

        MinusHPofCrash = 16.2f;       //임의로 10번 부딪히면 죽도록 설정

        MiniPortion = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (NowHp <= 0)
        {
            DeadChecker();

            MoveScene.Instance.OpenGameEndScene();
        }
    }

    /// <summary>
    /// 키(버튼) 가 눌렸을 때 캐릭터가 점프하는 함수
    /// </summary>
    public void JumpCookie()
    {
        if (CookieAni.GetBool("Running") == true && nowJumpCount < 1)      // 캐릭터가 기본상태인 Running 일 때
        {
            CookieAni.SetBool("Running", false);
            CookieAni.SetBool("Jump", true);
            playerRigid.velocity = new Vector3(0, firstJumpPower, 0);           // y 좌표의 값만 바꿔준다
            nowJumpCount++;

            // Debug.Log("JumpCount : " + nowJumpCount);
            // Debug.Log("a");

        }
        else if (CookieAni.GetBool("Jump") == true)           // 캐릭터가 Jump 상태일 때
        {
            nowJumpCount++;
            CookieAni.SetBool("Jump", false);
            CookieAni.SetBool("DoubleJump", true);

            playerRigid.velocity = new Vector3(0, secondJumpPower, 0);

            // Debug.Log("JumpCount : " + nowJumpCount);
            // Debug.Log("b");
        }
    }

    public void CrashCookie()
    {
        if (CookieAni.GetBool("Running") == true)
        {
            CookieAni.SetBool("Running", false);
            CookieAni.SetBool("Crash", true);
        }
        else if (CookieAni.GetBool("Jump") == true)
        {
            CookieAni.SetBool("Running", false);
            CookieAni.SetBool("Crash", true);
        }
        else if (CookieAni.GetBool("DoubleJump") == true)
        {
            CookieAni.SetBool("Running", false);
            CookieAni.SetBool("Crash", true);
        }
    }

    public void OffCrashCookie()
    {
        CookieAni.SetBool("Running", true);
        CookieAni.SetBool("Crash", false);
    }

    /// <summary>
    /// 쿠키가 슬라이드 하는 함수
    /// 버튼이 눌리는 중이다 를 체크하려면?
    /// 
    /// </summary>
    public void SlideCookie()
    {
        if (CookieAni.GetBool("Jump") == false && CookieAni.GetBool("DoubleJump") == false && CookieAni.GetBool("Running") == true)
        {
            //Debug.Log("sliding : ");

            CookieAni.SetBool("Slide", true);
            CookieAni.SetBool("Running", false);

            BoxCol.size = new Vector2(0.5f, 0.2f);              // 현재 적용된 쿠키의 콜라이더의 사이즈를 바꿔준다
            BoxCol.offset = new Vector2(0.03f, -0.4f);          // 현재 적용된 쿠키의 콜라이더의 오프셋 값을 바꿔준다

            // Debug.Log("JumpCount : " + nowJumpCount);
        }
    }

    public void OffSlideCookie()
    {
        CookieAni.SetBool("Slide", false);
        CookieAni.SetBool("Running", true);

        BoxCol.size = new Vector3(0.3f, 0.37f, 0.0f);
        BoxCol.offset = new Vector2(0.03f, -0.3f);
    }

    /// <summary>
    /// 오브젝트 끼리의 충돌 발생 시점에 수행할 함수 (현재 오브젝트의 콜라이더2D 가 다른 오브젝트의 콜라이더2D 와 닿을 때마다 유니티 엔진이 호출하는 메서드 )
    /// 캐릭터와 플랫폼이 충돌 시 점프를 위한 플래그들을 변경해 다시 점프 할 수 있도록 만들기 위한 함수
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 쿠키와 플랫폼 충돌시
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("FloatingPlatform"))
        {
            // isJumping = false;
            nowJumpCount = 0;
            if (CookieAni.GetBool("Jump") == true)
            {
                CookieAni.SetBool("Jump", false);
            }
            else if (CookieAni.GetBool("DoubleJump") == true)
            {
                CookieAni.SetBool("DoubleJump", false);
            }

            CookieAni.SetBool("Running", true);
        }

        // 쿠키와 트랩 충돌 시
        if (collision.gameObject.CompareTag("Trap"))
        {
            CrashCookie();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // 쿠키와 트랩 충돌 시
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            Debug.Log("쿠키 체력 : " + NowHp);

            OffCrashCookie();
        }
    }

    /// <summary>
    /// 쿠키가 젤리를 먹으면 점수가 추가되도록 하는 트리거 함수
    /// 젤리마다 점수를 다르게 먹기 위해, 충돌 시 어떤 젤리인지 판별 -> 점수를 다르게 증가시키도록 한다
    /// </summary>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 쿠키와 트랩 충돌 시
        if (collision.gameObject.CompareTag("Trap"))
        {
            ReduceHP();

            CrashCookie();
        }

        // 쿠키와 젤리들 충돌
        if (collision.gameObject.CompareTag("NormalJelly"))
        {
            GetNormalJellyScore();

            // collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("PinkJelly"))
        {
            GetPinkJellyScore();

            // collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("YellowJelly"))
        {
            GetYellowJellyScore();

            // collision.gameObject.SetActive(false);
        }

        // 쿠키와 코인 충돌
        if (collision.gameObject.CompareTag("CoinJelly"))
        {
            GetCoinScore();

            // collision.gameObject.SetActive(false);
        }

        // 쿠키와 포션 충돌
        if (collision.gameObject.CompareTag("MiniPortion"))
        {
            HealHP();
            Debug.Log("쿠키 체력 : " + NowHp);

            // collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("BigGoldCoin"))
        {
            GetBigGoldCoin();
            // collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("fallenCollider"))
        {
            DeadChecker();

            MoveScene.Instance.OpenGameEndScene();
        }

        if (collision.gameObject.CompareTag("GoalPoint"))
        {
            DeadChecker();

            MoveScene.Instance.OpenGameEndScene();
        }
    }

    /// <summary>
    /// 젤리와 충돌 시 점수 증가
    /// </summary>
    public void GetNormalJellyScore()
    {
        Jelly += NormalJelly;
        Debug.Log("젤리 점수 : " + Jelly);
    }

    public void GetPinkJellyScore()
    {
        Jelly += PinkJelly;
        Debug.Log("젤리 점수 : " + Jelly);
    }

    public void GetYellowJellyScore()
    {
        Jelly += YellowJelly;
        Debug.Log("젤리 점수 : " + Jelly);
    }

    /// <summary>
    /// 코인과 충돌 시 점수 증가
    /// </summary>
    public void GetCoinScore()
    {
        Coin += SilverCoin;
        Jelly += SilverCoinScore;

        Debug.Log("코인 점수 : " + Coin + " , " + "젤리 점수" + Jelly);
    }

    /// <summary>
    /// 쿠키의 체력이 0이 될 때 작동할 함수
    /// </summary>
    public void DeadChecker()
    {
        DontDestroy.Instance.SetCoinScore(Coin);

        DontDestroy.Instance.SetGameScore(Coin, Jelly);
    }

    /// <summary>
    /// 쿠키랑 트랩 충돌 시 체력 감소시킬 함수
    /// </summary>
    public void ReduceHP()
    {
        prevHP = NowHp;

        NowHp -= MinusHPofCrash;        // 우선 체력 감소

        if (NowHp != prevHP)
        {
            Hp.fillAmount -= 0.1f;

            /// 트리거 온 함수 -> 부딪혔을 때 
        }
    }

    /// <summary>
    /// 체력을 회복시켜줄 포션 함수
    /// </summary>
    public void HealHP()
    {
        prevHP = NowHp;

        NowHp += MiniPortion;

        if (NowHp != prevHP)
        {
            Hp.fillAmount += 0.08f;
        }
    }

    public void GetBigGoldCoin()
    {
        Coin += GoldCoin;
        Jelly += GoldCoinScore;

        Debug.Log("코인 점수 : " + Coin + " , " + "젤리 점수" + Jelly);
    }
}
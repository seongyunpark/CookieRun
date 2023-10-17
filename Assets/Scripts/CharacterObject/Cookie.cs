using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 2022.08.04 Mang
/// 
/// ��Ű ������ ���� ������ ���� ��ũ��Ʈ
/// ��Ű -> ����, �����̵�, �浹, �߷� �ʿ�
/// </summary>
public class Cookie : MonoBehaviour
{
    public static Cookie Instance;

    public Image Hp;                    // ü�¹ٰ� �پ�� �̹���

    public Rigidbody2D playerRigid;   // Rigidbody2D �Ӽ� ���� ����
    public Animator CookieAni;

    [SerializeField]
    private BoxCollider2D BoxCol;        // ��Ű�� �ൿ�� ���� �ݶ��̴��� �ٲ��ֱ� ���� ����

    public GameObject FallenCollision;

    public Button SlideButton;

    private float MiniPortion;          // ��Ű�� ü���� ȸ�������� ����

    public float firstJumpPower;     // �÷��̾� ���� �Ŀ�
    public float secondJumpPower;     // �÷��̾� ���� �Ŀ�

    float MaxHP;
    public float NowHp;             // ĳ������ ���� ü��
    float prevHP;
    public int Jelly;          // ���������� ��������
    public int Coin;           // ���� ����

    float MinusHPofCrash;       // ĳ���� Ʈ�� �浹�� �پ�� Hp ��

    int NormalJelly;            // �� ����, ���ε� ��
    int PinkJelly;
    int YellowJelly;

    int SilverCoin;
    int SilverCoinScore;
    int GoldCoin;
    int GoldCoinScore;

    int nowJumpCount;                   // ������ ��� �ߴ��� ī������ ����


    //public int count;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();        // rigid ������ Character�� Rigidbody2D �Ӽ����� �ʱ�ȭ

        CookieAni = GetComponent<Animator>();

        BoxCol = GetComponent<BoxCollider2D>();

        // Hp = GetComponent<Image>();                  // ������ �˾Ҵ�. ���ӿ�����Ʈ�� ������ ���� �ش� ������Ʈ�� �ް� 
        // Hp = image.GetComponent<Image>();            // �̷��� ������ �ذ� ���� ���̴�...!
        // �̷��� �����۳�Ʈ�� �Ƚᵵ �̹� �ۿ��� ������Ʈ�� ������ ����� ������ �����ϴ�..!

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

        MinusHPofCrash = 16.2f;       //���Ƿ� 10�� �ε����� �׵��� ����

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
    /// Ű(��ư) �� ������ �� ĳ���Ͱ� �����ϴ� �Լ�
    /// </summary>
    public void JumpCookie()
    {
        if (CookieAni.GetBool("Running") == true && nowJumpCount < 1)      // ĳ���Ͱ� �⺻������ Running �� ��
        {
            CookieAni.SetBool("Running", false);
            CookieAni.SetBool("Jump", true);
            playerRigid.velocity = new Vector3(0, firstJumpPower, 0);           // y ��ǥ�� ���� �ٲ��ش�
            nowJumpCount++;

            // Debug.Log("JumpCount : " + nowJumpCount);
            // Debug.Log("a");

        }
        else if (CookieAni.GetBool("Jump") == true)           // ĳ���Ͱ� Jump ������ ��
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
    /// ��Ű�� �����̵� �ϴ� �Լ�
    /// ��ư�� ������ ���̴� �� üũ�Ϸ���?
    /// 
    /// </summary>
    public void SlideCookie()
    {
        if (CookieAni.GetBool("Jump") == false && CookieAni.GetBool("DoubleJump") == false && CookieAni.GetBool("Running") == true)
        {
            //Debug.Log("sliding : ");

            CookieAni.SetBool("Slide", true);
            CookieAni.SetBool("Running", false);

            BoxCol.size = new Vector2(0.5f, 0.2f);              // ���� ����� ��Ű�� �ݶ��̴��� ����� �ٲ��ش�
            BoxCol.offset = new Vector2(0.03f, -0.4f);          // ���� ����� ��Ű�� �ݶ��̴��� ������ ���� �ٲ��ش�

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
    /// ������Ʈ ������ �浹 �߻� ������ ������ �Լ� (���� ������Ʈ�� �ݶ��̴�2D �� �ٸ� ������Ʈ�� �ݶ��̴�2D �� ���� ������ ����Ƽ ������ ȣ���ϴ� �޼��� )
    /// ĳ���Ϳ� �÷����� �浹 �� ������ ���� �÷��׵��� ������ �ٽ� ���� �� �� �ֵ��� ����� ���� �Լ�
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // ��Ű�� �÷��� �浹��
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

        // ��Ű�� Ʈ�� �浹 ��
        if (collision.gameObject.CompareTag("Trap"))
        {
            CrashCookie();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // ��Ű�� Ʈ�� �浹 ��
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            Debug.Log("��Ű ü�� : " + NowHp);

            OffCrashCookie();
        }
    }

    /// <summary>
    /// ��Ű�� ������ ������ ������ �߰��ǵ��� �ϴ� Ʈ���� �Լ�
    /// �������� ������ �ٸ��� �Ա� ����, �浹 �� � �������� �Ǻ� -> ������ �ٸ��� ������Ű���� �Ѵ�
    /// </summary>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ű�� Ʈ�� �浹 ��
        if (collision.gameObject.CompareTag("Trap"))
        {
            ReduceHP();

            CrashCookie();
        }

        // ��Ű�� ������ �浹
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

        // ��Ű�� ���� �浹
        if (collision.gameObject.CompareTag("CoinJelly"))
        {
            GetCoinScore();

            // collision.gameObject.SetActive(false);
        }

        // ��Ű�� ���� �浹
        if (collision.gameObject.CompareTag("MiniPortion"))
        {
            HealHP();
            Debug.Log("��Ű ü�� : " + NowHp);

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
    /// ������ �浹 �� ���� ����
    /// </summary>
    public void GetNormalJellyScore()
    {
        Jelly += NormalJelly;
        Debug.Log("���� ���� : " + Jelly);
    }

    public void GetPinkJellyScore()
    {
        Jelly += PinkJelly;
        Debug.Log("���� ���� : " + Jelly);
    }

    public void GetYellowJellyScore()
    {
        Jelly += YellowJelly;
        Debug.Log("���� ���� : " + Jelly);
    }

    /// <summary>
    /// ���ΰ� �浹 �� ���� ����
    /// </summary>
    public void GetCoinScore()
    {
        Coin += SilverCoin;
        Jelly += SilverCoinScore;

        Debug.Log("���� ���� : " + Coin + " , " + "���� ����" + Jelly);
    }

    /// <summary>
    /// ��Ű�� ü���� 0�� �� �� �۵��� �Լ�
    /// </summary>
    public void DeadChecker()
    {
        DontDestroy.Instance.SetCoinScore(Coin);

        DontDestroy.Instance.SetGameScore(Coin, Jelly);
    }

    /// <summary>
    /// ��Ű�� Ʈ�� �浹 �� ü�� ���ҽ�ų �Լ�
    /// </summary>
    public void ReduceHP()
    {
        prevHP = NowHp;

        NowHp -= MinusHPofCrash;        // �켱 ü�� ����

        if (NowHp != prevHP)
        {
            Hp.fillAmount -= 0.1f;

            /// Ʈ���� �� �Լ� -> �ε����� �� 
        }
    }

    /// <summary>
    /// ü���� ȸ�������� ���� �Լ�
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

        Debug.Log("���� ���� : " + Coin + " , " + "���� ����" + Jelly);
    }
}
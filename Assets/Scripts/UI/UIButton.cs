using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    // private bool isBtnDown = false;

    public Rigidbody2D rigid;
    public Text CoinText;
    public Text JellyScoreText;
    public Text CookieHP;

    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = "0";
        CookieHP.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        PrintCoinScore();       // ��������

        PrintJellyScore();      // ���� + ��������

        CookieHP.text = Cookie.Instance.NowHp.ToString();
    }

    /// <summary>
    /// �������� 1,000 ������ ����� �޸��� �����鼭 ����� �� �Լ�
    /// 
    /// </summary>
    public void PrintCoinScore()
    {
        if (Cookie.Instance.Coin != 0)
        {
            CoinText.text = string.Format("{0:#,###}", Cookie.Instance.Coin);           // string.Format("{0:#,###}", �Ķ����) �� string.Format �� ����Ͽ� ǥ�� ����
        }
        else if (Cookie.Instance.Coin == 0)
        {
            CoinText.text = "0";
        }
    }

    public void PrintJellyScore()
    {

        if (Cookie.Instance.Coin != 0)
        {
            JellyScoreText.text = string.Format("{0:#,###}", Cookie.Instance.Jelly);           // string.Format("{0:#,###}", �Ķ����) �� string.Format �� ����Ͽ� ǥ�� ����
        }
        else if (Cookie.Instance.Coin == 0)
        {
            CoinText.text = "0";
        }
    }
}

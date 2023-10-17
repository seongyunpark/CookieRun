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
        PrintCoinScore();       // 코인점수

        PrintJellyScore();      // 젤리 + 코인점수

        CookieHP.text = Cookie.Instance.NowHp.ToString();
    }

    /// <summary>
    /// 점수들을 1,000 단위로 나누어서 콤마를 찍으면서 출력해 줄 함수
    /// 
    /// </summary>
    public void PrintCoinScore()
    {
        if (Cookie.Instance.Coin != 0)
        {
            CoinText.text = string.Format("{0:#,###}", Cookie.Instance.Coin);           // string.Format("{0:#,###}", 파라미터) 이 string.Format 을 사용하여 표현 가능
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
            JellyScoreText.text = string.Format("{0:#,###}", Cookie.Instance.Jelly);           // string.Format("{0:#,###}", 파라미터) 이 string.Format 을 사용하여 표현 가능
        }
        else if (Cookie.Instance.Coin == 0)
        {
            CoinText.text = "0";
        }
    }
}

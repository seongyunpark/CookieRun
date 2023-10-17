using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022. 08. 11 Mang
/// 
/// 계속 데이터를 가지고 있을 변수들을 담은 static 클래스
/// </summary>
public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;

    public int GameScore;           // 모든 게임 점수

    public int CoinScore;           // 코인 증가

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 계속 저장 될 Coin 점수
    /// </summary>
    /// <param name="Coin"></param>
    public void SetCoinScore(int Coin)
    {
        CoinScore = Coin;
    }

    public int GetCoinScore() { return CoinScore; }

    /// <summary>
    /// 계속 저장 될 총 점수
    /// </summary>
    /// <param name="Coin"></param>
    /// <param name="Jelly"></param>
    public void SetGameScore(int Coin, int Jelly)
    {
        GameScore = Coin + Jelly;
    }

    public int GetGameScore() { return GameScore; }

}

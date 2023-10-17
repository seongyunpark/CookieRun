using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022. 08. 11 Mang
/// 
/// ��� �����͸� ������ ���� �������� ���� static Ŭ����
/// </summary>
public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;

    public int GameScore;           // ��� ���� ����

    public int CoinScore;           // ���� ����

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
    /// ��� ���� �� Coin ����
    /// </summary>
    /// <param name="Coin"></param>
    public void SetCoinScore(int Coin)
    {
        CoinScore = Coin;
    }

    public int GetCoinScore() { return CoinScore; }

    /// <summary>
    /// ��� ���� �� �� ����
    /// </summary>
    /// <param name="Coin"></param>
    /// <param name="Jelly"></param>
    public void SetGameScore(int Coin, int Jelly)
    {
        GameScore = Coin + Jelly;
    }

    public int GetGameScore() { return GameScore; }

}

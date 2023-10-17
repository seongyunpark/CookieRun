using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /// Inspector â���� ����ֱ� �� ������Ʈ���� GetComponent ���� ���� �������
    public Text GameScore;
    public Text CoinScore;

    // Start is called before the first frame update
    void Start()
    {
        GameScore.text = "0";
        CoinScore.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        DrawGameScore();
        DrawCoinScore();
    }

    /// <summary>
    /// ���⼭ ������ ������ �̰� ���� ������ ������ �Ǵµ� �� �� ���� ������ ���´�
    /// </summary>
    public void DrawGameScore()
    {
        GameScore.text = DontDestroy.Instance.GetGameScore().ToString();

        Debug.Log("���� ���� : " + GameScore);
    }
    public void DrawCoinScore()
    {
        CoinScore.text = DontDestroy.Instance.GetCoinScore().ToString();

        Debug.Log("���� ���� : " + CoinScore);
    }
}

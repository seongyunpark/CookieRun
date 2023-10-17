using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /// Inspector 창에서 끌어넣기 한 오브젝트들은 GetComponent 하지 말자 기억하자
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
    /// 여기서 오류가 난ㄴ다 이게 뭘까 점수가 연결은 되는데 둘 다 코인 점수가 나온다
    /// </summary>
    public void DrawGameScore()
    {
        GameScore.text = DontDestroy.Instance.GetGameScore().ToString();

        Debug.Log("게임 점수 : " + GameScore);
    }
    public void DrawCoinScore()
    {
        CoinScore.text = DontDestroy.Instance.GetCoinScore().ToString();

        Debug.Log("게임 점수 : " + CoinScore);
    }
}

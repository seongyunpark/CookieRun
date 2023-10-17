using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Text text;           // 연결 해 줄 텍스트 컴포넌트

    float time;                 // 흐르는 시간 변수
    float fadeTime;             // 깜빡이는 시간을 조절해줄 최대시간 변수

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        fadeTime = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        FadeOutAnim();
    }

    /// <summary>
    /// 버튼의 존재감을 드러내며 깜빡거리게 만들어줄 함수
    /// 
    /// </summary>
    public void FadeOutAnim()
    {
        if (time < fadeTime)            // 알파 1 -> 알파 0으로 변하는 함수
        {
            text.color = new Color(255, 203, 0, 1.0f - time / fadeTime);
        }
        else if (fadeTime <= time && time <= fadeTime * 2)      // 알파 0 -> 알파 1 로 변하는 함수
        {
            text.color = new Color(255, 203, 0, time / fadeTime - 1.0f);
        }
        else
        {
            time = 0;
        }

        time += Time.deltaTime;
    }
}

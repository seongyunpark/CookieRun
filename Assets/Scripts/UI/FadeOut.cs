using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Text text;           // ���� �� �� �ؽ�Ʈ ������Ʈ

    float time;                 // �帣�� �ð� ����
    float fadeTime;             // �����̴� �ð��� �������� �ִ�ð� ����

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
    /// ��ư�� ���簨�� �巯���� �����Ÿ��� ������� �Լ�
    /// 
    /// </summary>
    public void FadeOutAnim()
    {
        if (time < fadeTime)            // ���� 1 -> ���� 0���� ���ϴ� �Լ�
        {
            text.color = new Color(255, 203, 0, 1.0f - time / fadeTime);
        }
        else if (fadeTime <= time && time <= fadeTime * 2)      // ���� 0 -> ���� 1 �� ���ϴ� �Լ�
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

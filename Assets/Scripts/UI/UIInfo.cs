using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfo : MonoBehaviour
{
    public GameObject InGameButton;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //InGameButton.SetActive(false);      // �޴��г� ��Ȱ��ȭ
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// InGame ���� ������ Pause ��ư�� ������ �޴��� �ߵ��� �ϴ� �Լ�
    /// </summary>
    public void OpenInGameMenu()
    {

        Time.timeScale = 0;                         // ���� �������� ���ø����̼��� �ð� ����
        InGameButton.SetActive(true);               // ��Ȱ��ȭ �Ǿ��ִ� �г� Ȱ��ȭ
    }

    public void PressRestartButton()
    {
        Time.timeScale = 1;                         // ���� �������� ���ø����̼��� �ð� ������
        InGameButton.SetActive(false);              // ��Ȱ��ȭ �Ǿ��ִ� �г� Ȱ��ȭ
    }

    /// <summary>
    /// Build �� Unity Application�� �����ϱ� ���� �켱 ���� ���� �����Լ�
    /// </summary>
    public void PressQuitButton()
    {
        // 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;        // ����Ƽ �����Ϳ��� ���� �ǵ��� ���ִ� �ڵ� -> if Ű���带 �̿��Ͽ� �÷������� �ٸ��� �����ϰ� ����� ��. �̷��� ���ϸ� ������ �� ������
#else
        Application.Quit();         // ���� �� ���ø����̼ǿ����� ������ ���� ��
#endif
    }
}

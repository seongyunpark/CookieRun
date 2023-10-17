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
        //InGameButton.SetActive(false);      // 메뉴패널 비활성화
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// InGame 에서 우상단의 Pause 버튼을 누르면 메뉴가 뜨도록 하는 함수
    /// </summary>
    public void OpenInGameMenu()
    {

        Time.timeScale = 0;                         // 현재 진행중인 어플리케이션의 시간 정지
        InGameButton.SetActive(true);               // 비활성화 되어있는 패널 활성화
    }

    public void PressRestartButton()
    {
        Time.timeScale = 1;                         // 현재 진행중인 어플리케이션의 시간 움직임
        InGameButton.SetActive(false);              // 비활성화 되어있는 패널 활성화
    }

    /// <summary>
    /// Build 후 Unity Application을 종료하기 위해 우선 만든 게임 종료함수
    /// </summary>
    public void PressQuitButton()
    {
        // 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;        // 유니티 에디터에서 종료 되도록 해주는 코드 -> if 키워드를 이용하여 플랫폼별로 다르게 실행하게 해줘야 함. 이렇게 안하면 빌드할 때 오류남
#else
        Application.Quit();         // 빌드 된 어플리케이션에서는 무사히 종료 됨
#endif
    }
}

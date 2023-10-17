using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public static MoveScene Instance;

    private void Awake()
    {
        // if (Instance != null)
        // {
        //     Destroy(gameObject);

        //     return;
        //}

        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PixScreen();
    }

    // Update is called once per frame
    void Update()
    {
    }

    ///  -> 로딩
    public void OpenLoadingScene()
    {
        PixScreen();

        SceneManager.LoadScene("Loading");
    }

    ///  -> 메인로비
    ///  게임이 끝나고 돌아오는 루틴
    public void OpenMainLobbyScene()
    {
        PixScreen();

        SceneManager.LoadScene("MainLobby");

        DontDestroy.Instance.GameScore = 0;
        DontDestroy.Instance.CoinScore = 0;
    }

    ///  -> 인게임
    public void OpenInGameScene()
    {
        PixScreen();

        SceneManager.LoadScene("InGame");
    }

    ///  -> 게임엔드
    public void OpenGameEndScene()
    {
        PixScreen();

        if (Cookie.Instance.NowHp <= 0.0f)
        {
            SceneManager.LoadScene("GameEnd");
        }
        else
        {
            SceneManager.LoadScene("GameEnd");

            Time.timeScale = 1;
        }
    }

    ////////////////////////////////////////////

    /// -> 캐릭터 선택 씬
    public void OpenSelectingCharacterScene()
    {
        PixScreen();

        SceneManager.LoadScene("SelectingCharacter");
    }

    /// -> 스테이지 선택 씬
    public void OpenSelectingStageScene()
    {
        PixScreen();

        SceneManager.LoadScene("SelectingStage");
    }

    /// <summary>
    /// 모바일 화면에서 가로세로 고정하기 위한 함수
    /// </summary>
    private void PixScreen()
    {
        Screen.autorotateToPortrait = false;                // 세로방향
       
        Screen.autorotateToPortraitUpsideDown = false;         // 장치 윗부분이 아래 향하는 세로방향

        Screen.autorotateToLandscapeLeft = true;            // 충전단자가 오른쪽인 가로방향 (반 시계방향으로 회전한 가로방향)

        Screen.autorotateToLandscapeRight = true;           // 충전단자가 왼쪽인 가로방향 (시계방향으로 회전한 가로방향)
    }

}

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

    ///  -> �ε�
    public void OpenLoadingScene()
    {
        PixScreen();

        SceneManager.LoadScene("Loading");
    }

    ///  -> ���ηκ�
    ///  ������ ������ ���ƿ��� ��ƾ
    public void OpenMainLobbyScene()
    {
        PixScreen();

        SceneManager.LoadScene("MainLobby");

        DontDestroy.Instance.GameScore = 0;
        DontDestroy.Instance.CoinScore = 0;
    }

    ///  -> �ΰ���
    public void OpenInGameScene()
    {
        PixScreen();

        SceneManager.LoadScene("InGame");
    }

    ///  -> ���ӿ���
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

    /// -> ĳ���� ���� ��
    public void OpenSelectingCharacterScene()
    {
        PixScreen();

        SceneManager.LoadScene("SelectingCharacter");
    }

    /// -> �������� ���� ��
    public void OpenSelectingStageScene()
    {
        PixScreen();

        SceneManager.LoadScene("SelectingStage");
    }

    /// <summary>
    /// ����� ȭ�鿡�� ���μ��� �����ϱ� ���� �Լ�
    /// </summary>
    private void PixScreen()
    {
        Screen.autorotateToPortrait = false;                // ���ι���
       
        Screen.autorotateToPortraitUpsideDown = false;         // ��ġ ���κ��� �Ʒ� ���ϴ� ���ι���

        Screen.autorotateToLandscapeLeft = true;            // �������ڰ� �������� ���ι��� (�� �ð�������� ȸ���� ���ι���)

        Screen.autorotateToLandscapeRight = true;           // �������ڰ� ������ ���ι��� (�ð�������� ȸ���� ���ι���)
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CFollowEngine : MonoBehaviour
{
    #region SingleTon
    public static CFollowEngine _instance = null;

    public static CFollowEngine Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CFollowEngine install null");

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            _instance = null;
        }
    }
    #endregion

    public GameObject[] m_listBoard = new GameObject[5];

    public GameObject[] m_listBoard21Stage = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        //CGameData.Instance.SetStage(21002);

        PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        int nStage = CGameData.Instance.GetStage();

        if (nStage < 22000)
        {
            ShowBoard(0);
            ShowBoard21Stage(nStage - 21000);
            CUIsFollow.Instance.ShowBoardUi(0);
            CUIsFollow.Instance.ShowBoard21Quiz(nStage - 21000);
        }
        else if (nStage < 23000)
        {
            ShowBoard(1);
            CUIsFollow.Instance.ShowBoardUi(1);
        }
        else if (nStage < 24000)
        {
            ShowBoard(2);
            CUIsFollow.Instance.ShowBoardUi(2);
        }
        else if (nStage < 25000)
        {
            ShowBoard(3);
            CUIsFollow.Instance.ShowBoardUi(3);
        }
        else if (nStage < 26000)
        {
            ShowBoard(4);
            CUIsFollow.Instance.ShowBoardUi(4);
        }
    }

    public void HideAllBoard()
    {
        for(int i = 0; i < m_listBoard.Length; i++)
        {
            m_listBoard[i].gameObject.SetActive(false);
        }
    }

    public void ShowBoard(int nIndex)
    {
        HideAllBoard();
        m_listBoard[nIndex].gameObject.SetActive(true);
    }

    public void HideAllBoard21Stage()
    {
        for(int i = 0; i < m_listBoard21Stage.Length; i++)
        {
            m_listBoard21Stage[i].gameObject.SetActive(false);
        }
    }

    public void ShowBoard21Stage(int nStage)
    {
        HideAllBoard21Stage();
        m_listBoard21Stage[nStage - 1].gameObject.SetActive(true);
    }

    public void LoadLobby()
    {
        CGameData.Instance.SetLobbyPage(3);
        SceneManager.LoadScene("Lobby");
    }

    public void LoadFollow()
    {
        SceneManager.LoadScene("Follow");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CLobbyManager : MonoBehaviour
{
    #region SingleTon
    public static CLobbyManager _instance = null;

    public static CLobbyManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CLobbyManager install null");

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

    public GameObject[] m_listUIs = new GameObject[7];

    public GameObject m_goTitle;

    public GameObject m_goSetup;

    public GameObject m_goBtnHome;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();


        ShowUIs(CGameData.Instance.GetLobbyPage());
        HideSetup();
        //ShowUIs(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideUIs(int nIndex)
    {
        m_listUIs[nIndex].SetActive(false);
    }

    public void HideAllUIs()
    {
        for(int i = 0; i < m_listUIs.Length; i++)
        {
            HideUIs(i);
        }
    }

    public void ShowUIs(int nIndex)
    {
        HideAllUIs();
        m_listUIs[nIndex].SetActive(true);

        if (nIndex > 1 && nIndex < 6)
            m_goBtnHome.SetActive(true);
        else
            m_goBtnHome.SetActive(false);

        //if (nIndex == 0)
        //    m_goTitle.SetActive(true);
        //else
        //    m_goTitle.SetActive(false);

        //SceneManager.LoadScene("Lobby");
    }
    public void ShowSetup()
    {
        m_goSetup.SetActive(true);
    }


    public void HideSetup()
    {
        m_goSetup.SetActive(false);
    }

    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void LoadFollow()
    {
        SceneManager.LoadScene("Follow");
    }

    public void LoadMusic()
    {
        SceneManager.LoadScene("Music");
    }

    public void LoadEmo()
    {
        SceneManager.LoadScene("Emo");
    }

    public void OnClickPlayGame(int nStage)
    {
        CGameData.Instance.SetStage(nStage);
        if (nStage < 20000)
            LoadInGame();
        else if (nStage < 30000)
            LoadFollow();
        else if (nStage < 40000)
            LoadMusic();
        else if (nStage < 50000)
            LoadEmo();
    }
}

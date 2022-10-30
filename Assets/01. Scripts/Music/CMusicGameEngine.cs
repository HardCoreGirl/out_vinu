using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CMusicGameEngine : MonoBehaviour
{
    #region SingleTon
    public static CMusicGameEngine _instance = null;

    public static CMusicGameEngine Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CMusicGameEnginee install null");

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

    public GameObject[] m_listBoard = new GameObject[2];
    public GameObject[] m_listUIBoard = new GameObject[2];
    public GameObject m_goUISetup;

    public GameObject m_goSetup;

    public GameObject[] m_listFrame1Stage = new GameObject[4];
    public GameObject[] m_listFrame3Stage = new GameObject[2];

    public GameObject m_goFrame3Stage;

    public GameObject m_goFrame4Stage;

    private bool m_bFrame3Playing = false;
    private float m_fFrame3Speed = 3.0f;

    private bool m_bFrame4Playing = false;
    private float m_fFrame4Speed = 1.0f;

    private float m_fFrame3StartPoz = 0;
    private float m_fFrame3FinishPoz = -600;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        PlayGame();

        HideSetup();
        HideUISetup();
        //PlayFrame3();
        //PlayFrame3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        int nStage = CGameData.Instance.GetStage();

        if (nStage < 32000)
        {
            ShowBoard(0);
            ShowUIBoard(0);
            ShowFrame1Stage(0);
        }
        else if (nStage < 33000)
        {
            ShowBoard(1);
            ShowUIBoard(1);
        }
    }

    public void HideAllBoard()
    {
        for (int i = 0; i < m_listBoard.Length; i++)
            HideBoard(i);
    }

    public void ShowBoard(int nIndex)
    {
        HideAllBoard();
        m_listBoard[nIndex].SetActive(true);
    }

    public void HideBoard(int nIndex)
    {
        m_listBoard[nIndex].SetActive(false);
    }

    public void HideAllUIBoard()
    {
        for(int i = 0; i < m_listUIBoard.Length; i++)
            HideUIBoard(i);
    }

    public void ShowUIBoard(int nIndex)
    {
        HideAllUIBoard();
        m_listUIBoard[nIndex].SetActive(true);
    }

    public void HideUIBoard(int nIndex)
    {
        m_listUIBoard[nIndex].SetActive(false);
    }

    public void ShowSetup()
    {
        m_goSetup.SetActive(true);
        ShowUISetup();
    }

    public void HideSetup()
    {
        m_goSetup.SetActive(false);
    }

    public void ShowUISetup()
    {
        HideAllUIBoard();
        m_goUISetup.SetActive(true);
    }

    public void HideUISetup()
    {
        m_goUISetup.SetActive(false);
    }

    public int GetFrame1StageCnt()
    {
        return m_listFrame1Stage.Length;
    }

    public void HideAllFrame1Stages()
    {
        for(int i = 0; i < m_listFrame1Stage.Length; i++)
        {
            HideFrame1Stage(i);
        }
    }

    public void ShowFrame1Stage(int nIndex)
    {
        HideAllFrame1Stages();
        m_listFrame1Stage[nIndex].SetActive(true);
    }

    public void HideFrame1Stage(int nIndex)
    {
        Debug.Log("HideFame1Stage : " + nIndex);
        if(m_listFrame1Stage[nIndex].activeSelf)
            m_listFrame1Stage[nIndex].SetActive(false);
    }

    public void PlayFrame3(int nIndex)
    {
        StopCoroutine("ProcessPlayFrame3");
        m_bFrame3Playing = true;
        if (nIndex == 0)
        {
            m_fFrame3StartPoz = 0;
            m_fFrame3FinishPoz = -50.6f;
        } else if ( nIndex == 1 )
        {
            m_fFrame3StartPoz = -50.6f;
            m_fFrame3FinishPoz = -106.9f;
        } else if (nIndex == 2)
        {
            m_fFrame3StartPoz = -106.9f;
            m_fFrame3FinishPoz = -182.6f;
        } else if (nIndex == 3 )
        {
            m_fFrame3StartPoz = -182.6f;
            m_fFrame3FinishPoz = -276.6f;
        }
        else if (nIndex == 4)
        {
            m_fFrame3StartPoz = -276.6f;
            m_fFrame3FinishPoz = -352.3f;
        }
        else if (nIndex == 5)
        {
            m_fFrame3StartPoz = -352.3f;
            m_fFrame3FinishPoz = -397.9f;
        }
        else if (nIndex == 6)
        {
            m_fFrame3StartPoz = -397.9f;
            m_fFrame3FinishPoz = -458.2f;
        }
        else if (nIndex == 7)
        {
            m_fFrame3StartPoz = -458.2f;
            m_fFrame3FinishPoz = -600f;
        }

        StartCoroutine("ProcessPlayFrame3");
    }

    public void PlayFrame3()
    {
        m_bFrame3Playing = true;
        m_fFrame3StartPoz = 0;
        m_fFrame3FinishPoz = -600;

        StartCoroutine("ProcessPlayFrame3");
    }

    IEnumerator ProcessPlayFrame3()
    {
        m_goFrame3Stage.transform.localPosition = new Vector3(0, m_fFrame3StartPoz, 0);
        Vector3 vecNow = m_goFrame3Stage.transform.localPosition;
        while (true)
        {
            vecNow = m_goFrame3Stage.transform.localPosition;
            vecNow.y -= (Time.deltaTime * m_fFrame3Speed);
            m_goFrame3Stage.transform.localPosition = vecNow;

            if (vecNow.y <= m_fFrame3FinishPoz)
                break;

            yield return new WaitForEndOfFrame();
        }

        m_goFrame3Stage.transform.localPosition = new Vector3(0, 0, 0);
        m_bFrame3Playing = false;
    }

    public bool IsFrame3Playing()
    {
        return m_bFrame3Playing;
    }

    public void SetFrame3Speed(float fSpeed)
    {
        m_fFrame3Speed = fSpeed;
    }

    public float GetFrame3Speed()
    {
        return m_fFrame3Speed;
    }


    public void PlayFrame4()
    {
        m_bFrame4Playing = true;
        StartCoroutine("ProcessPlayFrame4");
    }

    IEnumerator ProcessPlayFrame4()
    {
        Vector3 vecNow = m_goFrame4Stage.transform.localPosition;
        while (true)
        {
            vecNow = m_goFrame4Stage.transform.localPosition;
            vecNow.y -= (Time.deltaTime * m_fFrame4Speed);
            m_goFrame4Stage.transform.localPosition = vecNow;

            if (vecNow.y <= -340)
                break;

            yield return new WaitForEndOfFrame();
        }

        m_goFrame4Stage.transform.localPosition = new Vector3(0, 0, 0);
        m_bFrame4Playing = false;
    }

    public bool IsFrame4Playing()
    {
        return m_bFrame4Playing;
    }

    public void SetFrame4Speed(float fSpeed)
    {
        m_fFrame4Speed = fSpeed;
    }

    public float GetFrame4Speed()
    {
        return m_fFrame4Speed;
    }

    public void OnClickNext()
    {
        int nStage = CGameData.Instance.GetStage() + 1;
        //if (nStage > 32003)
        if (nStage > 32007)
        {
            LoadHome();
            return;
        }

        CGameData.Instance.SetStage(nStage);
        //LoadMusicGame();
    }

    public void LoadMusicGame()
    {
        SceneManager.LoadScene("Music");
    }

    public void LoadHome()
    {
        CGameData.Instance.SetLobbyPage(1);
        SceneManager.LoadScene("Lobby");
    }

    public void LoadHome2()
    {
        CGameData.Instance.SetLobbyPage(4);
        SceneManager.LoadScene("Lobby");
    }
}

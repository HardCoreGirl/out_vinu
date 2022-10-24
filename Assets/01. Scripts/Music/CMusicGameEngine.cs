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

    public GameObject[] m_listFrame1Stage = new GameObject[4];
    public GameObject[] m_listFrame3Stage = new GameObject[2];

    public GameObject m_goFrame3Stage;

    public GameObject m_goFrame4Stage;

    private bool m_bFrame3Playing = false;
    private float m_fFrame3Speed = 3.0f;

    private bool m_bFrame4Playing = false;
    private float m_fFrame4Speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        PlayGame();

        ShowFrame1Stage(0);
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
        }
        else if (nStage < 33000)
        {
        }
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
        m_listFrame1Stage[nIndex].SetActive(false);
    }

    public void PlayFrame3()
    {
        m_bFrame3Playing = true;
        StartCoroutine("ProcessPlayFrame3");
    }

    IEnumerator ProcessPlayFrame3()
    {
        Vector3 vecNow = m_goFrame3Stage.transform.localPosition;
        while (true)
        {
            vecNow = m_goFrame3Stage.transform.localPosition;
            vecNow.y -= (Time.deltaTime * m_fFrame3Speed);
            m_goFrame3Stage.transform.localPosition = vecNow;

            if (vecNow.y <= -600)
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
        if (nStage > 32004)
        {
            LoadHome();
            return;
        }

        CGameData.Instance.SetStage(nStage);
        LoadMusicGame();
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
}

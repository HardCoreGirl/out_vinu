using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsFollow : MonoBehaviour
{
    #region SingleTon
    public static CUIsFollow _instance = null;

    public static CUIsFollow Instance
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

    public GameObject[] m_listBoardUI = new GameObject[5];

    public GameObject[] m_listBoard21Quiz = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAllBoardUIs()
    {
        for(int i = 0; i < m_listBoardUI.Length; i++)
        {
            m_listBoardUI[i].gameObject.SetActive(false);
        }
    }

    public void ShowBoardUi(int nIndex)
    {
        HideAllBoardUIs();
        m_listBoardUI[nIndex].gameObject.SetActive(true);
    }

    public void HideAllBoard21Quiz()
    {
        for(int i = 0; i < m_listBoard21Quiz.Length; i++)
        {
            m_listBoard21Quiz[i].SetActive(false);
        }
    }

    public void ShowBoard21Quiz(int nStage)
    {
        HideAllBoard21Quiz();

        m_listBoard21Quiz[(nStage - 1) * 2 ].SetActive(true);
        m_listBoard21Quiz[((nStage - 1)* 2) + 1].SetActive(true);
    }


    public void OnClickNext()
    {
        int nStage = CGameData.Instance.GetStage() + 1;
        if( nStage >= 21005 )
        {
            CFollowEngine.Instance.LoadLobby();
        } else
        {
            CGameData.Instance.SetStage(nStage);
            CFollowEngine.Instance.LoadFollow();
        }
    }
}

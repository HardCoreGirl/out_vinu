using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CEmoGameEngine : MonoBehaviour
{
    #region SingleTon
    public static CEmoGameEngine _instance = null;

    public static CEmoGameEngine Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CEmoGameEngine install null");

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

    public GameObject[] m_listPlayerBoard = new GameObject[4];

    private int[] m_listSelectColor = new int[4];

    private string[] m_listSelectEmo = new string[2];

    public GameObject[] m_listTopEmo = new GameObject[49];
    public  GameObject[] m_listBottomEmo = new GameObject[49];
    private Vector3 m_vecMouseDownPos;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        SetSelectEmo(0, "A");
        SetSelectEmo(1, "A");

        for (int i = 0; i < m_listPlayerBoard.Length; i++)
        {
            m_listPlayerBoard[i].GetComponent<CUIsEmoPlayBoard>().InitUIEmoPlayBoard();
        }

        for (int i = 0; i < m_listSelectColor.Length; i++)
        {
            SetSelectColor(i, 0);
        }

        for (int i = 0; i < m_listTopEmo.Length; i++)
        {
            m_listTopEmo[i].GetComponent<CUIsBtnEmo>().InitObject();
        }


        for ( int i = 0; i < m_listBottomEmo.Length; i++)
        {
            m_listBottomEmo[i].GetComponent<CUIsBtnEmo>().InitObject();
        }

        

        //m_listPlayerBoard[3].GetComponent<CUIsEmoPlayBoard>().UpdateDotFromEmo("CI01");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_vecMouseDownPos = Input.mousePosition;

            Vector2 pos = Camera.main.ScreenToWorldPoint(m_vecMouseDownPos);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if( hit.collider != null)
            {
                if (hit.collider.gameObject.tag.ToString().Equals("Dot_1"))
                    hit.collider.gameObject.GetComponent<CEmoDot>().UpdateDot(GetSelectorColor(0));
                else if (hit.collider.gameObject.tag.ToString().Equals("Dot_2"))
                    hit.collider.gameObject.GetComponent<CEmoDot>().UpdateDot(GetSelectorColor(1));
                else if (hit.collider.gameObject.tag.ToString().Equals("Dot_3"))
                    hit.collider.gameObject.GetComponent<CEmoDot>().UpdateDot(GetSelectorColor(2));
                else if (hit.collider.gameObject.tag.ToString().Equals("Dot_4"))
                    hit.collider.gameObject.GetComponent<CEmoDot>().UpdateDot(GetSelectorColor(3));
            }
        }
    }

    public void SetSelectColor(int nPlayerIndex, int nColorIndex)
    {
        m_listSelectColor[nPlayerIndex] = nColorIndex;
    }

    public int GetSelectorColor(int nPlayerIndex)
    {
        return m_listSelectColor[nPlayerIndex];
    }

    public void SetSelectEmo(int nBoardIndex, string strEmo)
    {
        m_listSelectEmo[nBoardIndex] = strEmo;
    }

    public string GetSelectEmo(int nBoardIndex)
    {
        return m_listSelectEmo[nBoardIndex];
    }

    public void UpdateButtonColor(int nPlayerIndex)
    {
        m_listPlayerBoard[nPlayerIndex].GetComponent<CUIsEmoPlayBoard>().UpdateBtn();
    }

    public void UpdateEmoBoard(int nBoardIndex, string strEmo)
    {
        m_listPlayerBoard[nBoardIndex].GetComponent<CUIsEmoPlayBoard>().UpdateDotFromEmo(strEmo);
    }

    public void UpdateEmoButton(int nBoardIndex)
    {
        if (nBoardIndex == 0)
        {
            for (int i = 0; i < m_listTopEmo.Length; i++)
            {
                m_listTopEmo[i].GetComponent<CUIsBtnEmo>().UpdateButton();
            }
        }    
        else if( nBoardIndex == 1)
        {
            for (int i = 0; i < m_listBottomEmo.Length; i++)
            {
                m_listBottomEmo[i].GetComponent<CUIsBtnEmo>().UpdateButton();
            }

        }
    }

    public void OnClickTopEmo(string strEmoKey)
    {
        SetSelectEmo(0, strEmoKey);
        UpdateEmoButton(0);
    }


    public void OnClickBottomEmo(string strEmoKey)
    {
        SetSelectEmo(1, strEmoKey);
        UpdateEmoButton(1);
    }

    public void OnClickHome()
    {
        CGameData.Instance.SetLobbyPage(2);
        SceneManager.LoadScene("Lobby");
    }
}


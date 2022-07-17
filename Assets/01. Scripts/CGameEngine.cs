using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

public class CGameEngine : MonoBehaviour
{
    #region SingleTon
    public static CGameEngine _instance = null;

    public static CGameEngine Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CGameEngine install null");

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

    public GameObject[] m_listTestBG = new GameObject[6];

    public GameObject[] m_listFrameParent = new GameObject[4];

    public GameObject[] m_listQuizMath = new GameObject[2];

    public GameObject[] m_goUIBoard = new GameObject[2];

    public GameObject[] m_listAnswerTile = new GameObject[4];

    public GameObject m_goQuiz;

    public GameObject m_goTutorial;

    public VideoPlayer[] m_listTutorialMathVideo = new VideoPlayer[4];

    private int m_nGameStep = 0;

    private float[] m_listXpoz = new float[9];
    private float[] m_listYpoz = new float[4];

    // Start is called before the first frame update
    void Start()
    {
        m_listXpoz[0] = -3.89f;
        m_listXpoz[1] = -2.91f;
        m_listXpoz[2] = -1.95f;
        m_listXpoz[3] = -0.97f;
        m_listXpoz[4] = 0f;
        m_listXpoz[5] = 0.97f;
        m_listXpoz[6] = 1.95f;
        m_listXpoz[7] = 2.91f;
        m_listXpoz[8] = 3.89f;

        m_listYpoz[0] = 1.45f;
        m_listYpoz[1] = 0.49f;
        m_listYpoz[2] = -0.49f;
        m_listYpoz[3] = -1.45f;

        //HideAllTestBG();
        //ShowTestBG(0);

        m_goUIBoard[0].GetComponent<CUIsBoard001>().HideBtnsNext();
        m_goUIBoard[0].GetComponent<CUIsBoard001>().HideAnswer();
        m_goUIBoard[0].GetComponent<CUIsBoard001>().HideAllQuiz();

        m_goTutorial.SetActive(false);

        HideAnswerTile();

        //for (int i = 0; i < m_listQuizMath.Length; i++)
        //{
        //    m_listQuizMath[i].SetActive(false);
        //}

        StartCoroutine("ProcessShowTile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ProcessShowTile()
    {
        float fInterval = 0.1f;

        m_goQuiz.SetActive(true);

        

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("", i, 0, 3, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("", i, 0, 2);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("8", i, 0, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("6", i, 1, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("7", i, 0, 0);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("9", i, 1, 0);
        }
        yield return new WaitForSeconds(fInterval);


        yield return new WaitForSeconds(1.0f);

        SetGameStep(1);

        m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowQuiz(0);
        
        m_goQuiz.SetActive(false);

        for (int i = 0; i < m_listQuizMath.Length; i++)
        {
            m_listQuizMath[i].SetActive(true);
        }

        m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowBtnsNext();

        

    }

    public void SetGameStep(int nStep)
    {
        m_nGameStep = nStep;
    }

    public int GetGameStep()
    {
        return m_nGameStep;
    }

    public void ShowTestBG(int nIndex)
    {
        m_listTestBG[nIndex].SetActive(true);
    }

    public void HideAllTestBG()
    {
        for(int i = 0; i < m_listTestBG.Length; i++)
        {
            HideTestBG(i);
        }
    }

    public void HideTestBG(int nIndex)
    {
        m_listTestBG[nIndex].SetActive(false);
    }

    public void ShowTutorial(int nIndex)
    {
        m_goTutorial.SetActive(true);
    }

    public void HideTutorial()
    {
        m_goTutorial.SetActive(false);
    }

    public void PlayerTutorialVideo(int nIndex, int nType = 0)
    {
        m_listTutorialMathVideo[nIndex].Play();
    }

    public void ShowAnswerTile(int nXPoz, int nYPoz)
    {
        for(int i = 0; i < m_listAnswerTile.Length; i++)
        {
            m_listAnswerTile[i].SetActive(true);

            if (i == 0)
                m_listAnswerTile[i].transform.localPosition = new Vector3(-m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);
            else if (i == 1)
                m_listAnswerTile[i].transform.localPosition = new Vector3(m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);
            else if (i == 2)
                m_listAnswerTile[i].transform.localPosition = new Vector3(m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);
            else if (i == 3)
                m_listAnswerTile[i].transform.localPosition = new Vector3(-m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);
        }    
    }

    public void HideAnswerTile()
    {
        for (int i = 0; i < m_listAnswerTile.Length; i++)
        {
            m_listAnswerTile[i].SetActive(false);
        }
    }
}

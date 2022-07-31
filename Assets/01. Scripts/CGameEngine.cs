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

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        m_goUIBoard[0].GetComponent<CUIsBoard001>().HideBtnsNext();
        m_goUIBoard[0].GetComponent<CUIsBoard001>().HideAnswer();
        m_goUIBoard[0].GetComponent<CUIsBoard001>().HideAllQuiz();

        m_goTutorial.SetActive(false);

        HideAnswerTile();

        PlayGridStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGridStage()
    {
        int nStage = CGameData.Instance.GetStage();
        Debug.Log(nStage);
        if( nStage <= 2)     // 0, 1, 2
        {
            PlayGridStageMath();
        } else if (nStage <= 5)  // 3, 4, 5
        {
            PlayGridStageEnglish();
        } else   // 6, 7, 8
        {
            PlayGridStagePic();
        }
    }

    public void PlayGridStageMath()
    {
        StartCoroutine("ProcessShowTileMath");
    }

    IEnumerator ProcessShowTileMath()
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

        m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowQuiz(CGameData.Instance.GetStage());
        
        m_goQuiz.SetActive(false);

        for (int i = 0; i < m_listQuizMath.Length; i++)
        {
            m_listQuizMath[i].SetActive(true);
        }

        m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowBtnsNext();
    }

    public void PlayGridStageEnglish()
    {
        StartCoroutine("ProcessShowTileEnglish");
    }

    IEnumerator ProcessShowTileEnglish()
    {
        float fInterval = 0.1f;

        m_goQuiz.SetActive(true);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("", i, 0, 0, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("O", i, 1, 0);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("K", i, 2, 0);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("F", i, 1, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("P", i, 2, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("H", i, 3, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("Y", i, 2, 2);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("A", i, 3, 2);
        }
        yield return new WaitForSeconds(fInterval);


        yield return new WaitForSeconds(1.0f);

        SetGameStep(1);

        m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowQuiz(CGameData.Instance.GetStage());

        m_goQuiz.SetActive(false);

        for (int i = 0; i < m_listQuizMath.Length; i++)
        {
            m_listQuizMath[i].SetActive(true);
        }

        m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowBtnsNext();
    }

    public void PlayGridStagePic()
    {
        StartCoroutine("ProcessShowTilePic");
    }

    IEnumerator ProcessShowTilePic()
    {
        float fInterval = 0.1f;

        m_goQuiz.SetActive(true);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("", i, 2, 1, 1);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("PLANE", i, 2, 2);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("SHIP", i, 3, 2);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("BICYCLE", i, 4, 2);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("HELICOPTER", i, 3, 3);
        }
        yield return new WaitForSeconds(fInterval);

        for (int i = 0; i < m_listFrameParent.Length; i++)
        {
            GameObject goTile = Instantiate(Resources.Load("Prefabs/Tile") as GameObject);
            goTile.transform.SetParent(m_listFrameParent[i].transform);

            goTile.GetComponent<CTile>().InitObject("CAR", i, 4, 3);
        }
        yield return new WaitForSeconds(fInterval);

        yield return new WaitForSeconds(1.0f);

        SetGameStep(1);

        m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowQuiz(CGameData.Instance.GetStage());

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
                m_listAnswerTile[i].transform.localPosition = new Vector3(-CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);
            else if (i == 1)
                m_listAnswerTile[i].transform.localPosition = new Vector3(CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);
            else if (i == 2)
                m_listAnswerTile[i].transform.localPosition = new Vector3(CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);
            else if (i == 3)
                m_listAnswerTile[i].transform.localPosition = new Vector3(-CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);
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

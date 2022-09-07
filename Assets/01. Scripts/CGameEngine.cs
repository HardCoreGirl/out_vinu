using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

using UnityEngine.SceneManagement;

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

    public GameObject[] m_listGameBoard = new GameObject[2];

    public GameObject[] m_listTestBG = new GameObject[6];

    public GameObject[] m_listFrameParent = new GameObject[4];

    public GameObject[] m_listQuizMath = new GameObject[2];

    public GameObject m_goUICommon;
    public GameObject[] m_goUIBoard = new GameObject[2];

    public GameObject[] m_listAnswerTile = new GameObject[4];

    public GameObject[] m_listFrameType = new GameObject[2];
    public GameObject[] m_listBoard002Frames = new GameObject[4];
    public GameObject[] m_listFrameKor = new GameObject[4];

    public GameObject[] m_listAnswerType = new GameObject[2];
    public GameObject[] m_listBoard002Answer = new GameObject[4];
    public GameObject[] m_listAnswerKor = new GameObject[4];

    public GameObject[] m_listBoard002Star = new GameObject[8];
    public GameObject[] m_listStarKor = new GameObject[8];

    public GameObject[] m_listBoard002Toturial = new GameObject[4];
    public GameObject[] m_listToturialKor = new GameObject[4];

    public GameObject m_goQuiz;

    public GameObject m_goTutorial;

    public VideoPlayer[] m_listTutorialMathVideo = new VideoPlayer[4];

    private int m_nGameStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        //CGameData.Instance.SetStage(2000);
        //CGameData.Instance.SetStage(0);

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

        HideAllGameBoard();

        Debug.Log("PlayGridStage : " + nStage);
        if( nStage < 1000)
        {
            ShowGameBoard(0);
            if (nStage <= 2)     // 0, 1, 2
            {
                PlayGridStageMath();
            }
            else if (nStage <= 5)  // 3, 4, 5
            {
                PlayGridStageEnglish();
            }
            else   // 6, 7, 8
            {
                PlayGridStagePic();
            }
        } else if (nStage < 2000 )
        {
            ShowGameBoard(1);
            PlayGridStageTrash();
        } else if (nStage < 3000)
        {
            ShowGameBoard(1);
            PlayGridStageKorean();
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

    public void PlayGridStageTrash()
    {
        StartCoroutine("ProcessShowTileTrash");
    }

    IEnumerator ProcessShowTileTrash()
    {
        ShowFrameType(0);

        for(int i = 0; i < m_listBoard002Star.Length; i++)
        {
            m_listBoard002Star[i].SetActive(false);
        }

        for(int i = 0; i < m_listBoard002Toturial.Length; i++)
        {
            m_listBoard002Toturial[i].SetActive(false);
        }

        for(int i = 0; i < m_listBoard002Answer.Length; i++)
        {
            m_listBoard002Answer[i].SetActive(true);
            Color clr = Color.white;
            clr.a = 0;
            m_listBoard002Answer[i].GetComponent<SpriteRenderer>().color = clr;
        }

        for (int i = 0; i < m_listBoard002Frames.Length; i++)
        {
            if( i == 1 || i == 2)
                m_listBoard002Frames[i].transform.localPosition = new Vector3(2.2f, -6f, 0);
            else
                m_listBoard002Frames[i].transform.localPosition = new Vector3(-2.2f, -6f, 0);
        }

        float fTime = 0;
        float fFramePoz = 0;

        while(true)
        {
            fTime += (Time.deltaTime * 6);
            fFramePoz = fTime - 6;

            if (fFramePoz > 0.15)
                break;

            for (int i = 0; i < m_listBoard002Frames.Length; i++)
            {
                if (i == 1 || i == 2)
                    m_listBoard002Frames[i].transform.localPosition = new Vector3(2.2f, fFramePoz, 0);
                else
                    m_listBoard002Frames[i].transform.localPosition = new Vector3(-2.2f, fFramePoz, 0);
            }

            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < m_listBoard002Frames.Length; i++)
        {
            if (i == 1 || i == 2)
                m_listBoard002Frames[i].transform.localPosition = new Vector3(2.2f, 0.15f, 0);
            else
                m_listBoard002Frames[i].transform.localPosition = new Vector3(-2.2f, 0.15f, 0);
        }


        yield return new WaitForSeconds(0.1f);

        //m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowQuiz(CGameData.Instance.GetStage());
        m_goUICommon.GetComponent<CUIsCommon>().ShowQuiz(CGameData.Instance.GetStage());
        m_goUIBoard[1].SetActive(true);


        fTime = 0;

        SetGameStep(1);

        //StartCoroutine("ProcessShowStar");
    }

    public void ShowBoard002Answer()
    {
        StartCoroutine("ProcessShowBoard002Answer");
    }

    IEnumerator ProcessShowBoard002Answer()
    {
        for (int i = 0; i < m_listBoard002Toturial.Length; i++)
        {
            m_listBoard002Toturial[i].SetActive(true);
        }

        float fTime = 0;
        while (true)
        {
            fTime += (Time.deltaTime * 2f);
            if (fTime >= 1)
                break;

            for (int i = 0; i < m_listBoard002Answer.Length; i++)
            {
                m_listBoard002Answer[i].SetActive(true);
                Color clr = Color.white;
                clr.a = fTime;
                m_listBoard002Answer[i].GetComponent<SpriteRenderer>().color = clr;
            }

            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < m_listBoard002Answer.Length; i++)
        {
            m_listBoard002Answer[i].SetActive(true);
            Color clr = Color.white;
            m_listBoard002Answer[i].GetComponent<SpriteRenderer>().color = clr;
        }

        for (int i = 0; i < m_listBoard002Star.Length; i++)
        {
            m_listBoard002Star[i].SetActive(true);
        }

        float fScale = 1;
        int nDir = 0;

        int nCount = 0;
        while (true)
        {
            if (nDir == 0)
                fScale -= (Time.deltaTime * 1);
            else
                fScale += (Time.deltaTime * 1);

            if (fScale <= -1)
            {
                fScale = -1;
                nDir = 1;
            }
            else if (fScale >= 1)
            {
                fScale = 1;
                nDir = 0;
                nCount++;
            }

            if (nCount >= 2)
                break;

            for (int i = 0; i < m_listBoard002Star.Length; i++)
            {
                m_listBoard002Star[i].transform.localScale = new Vector3(fScale, 1, 1);
            }

            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < m_listBoard002Star.Length; i++)
        {
            m_listBoard002Star[i].transform.localScale = new Vector3(1, 1, 1);
        }

    }


    public void PlayGridStageKorean()
    {
        StartCoroutine("ProcessShowTileKorean");
    }

    IEnumerator ProcessShowTileKorean()
    {
        ShowFrameType(1);

        for (int i = 0; i < m_listStarKor.Length; i++)
        {
            m_listStarKor[i].SetActive(false);
        }

        for (int i = 0; i < m_listToturialKor.Length; i++)
        {
            m_listToturialKor[i].SetActive(false);
        }

        for (int i = 0; i < m_listAnswerKor.Length; i++)
        {
            m_listAnswerKor[i].SetActive(true);
            Color clr = Color.white;
            clr.a = 0;
            m_listAnswerKor[i].GetComponent<SpriteRenderer>().color = clr;
        }

        for (int i = 0; i < m_listFrameKor.Length; i++)
        {
            if (i == 1 || i == 2)
                m_listFrameKor[i].transform.localPosition = new Vector3(2.2f, -6f, 0);
            else
                m_listFrameKor[i].transform.localPosition = new Vector3(-2.2f, -6f, 0);
        }

        float fTime = 0;
        float fFramePoz = 0;

        while (true)
        {
            fTime += (Time.deltaTime * 6);
            fFramePoz = fTime - 6;

            if (fFramePoz > 0.15)
                break;

            for (int i = 0; i < m_listFrameKor.Length; i++)
            {
                if (i == 1 || i == 2)
                    m_listFrameKor[i].transform.localPosition = new Vector3(2.2f, fFramePoz, 0);
                else
                    m_listFrameKor[i].transform.localPosition = new Vector3(-2.2f, fFramePoz, 0);
            }

            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < m_listFrameKor.Length; i++)
        {
            if (i == 1 || i == 2)
                m_listFrameKor[i].transform.localPosition = new Vector3(2.2f, 0.15f, 0);
            else
                m_listFrameKor[i].transform.localPosition = new Vector3(-2.2f, 0.15f, 0);
        }


        yield return new WaitForSeconds(0.1f);

        //m_goUIBoard[0].GetComponent<CUIsBoard001>().ShowQuiz(CGameData.Instance.GetStage());
        m_goUICommon.GetComponent<CUIsCommon>().ShowQuiz(CGameData.Instance.GetStage());
        m_goUIBoard[1].SetActive(true);


        fTime = 0;

        SetGameStep(1);

        //StartCoroutine("ProcessShowStar");
    }

    public void ShowGridKorAnswer()
    {
        StartCoroutine("ProcessGridKorAnswer");
    }

    IEnumerator ProcessGridKorAnswer()
    {
        for (int i = 0; i < m_listToturialKor.Length; i++)
        {
            m_listToturialKor[i].SetActive(true);
        }

        float fTime = 0;
        while (true)
        {
            fTime += (Time.deltaTime * 2f);
            if (fTime >= 1)
                break;

            for (int i = 0; i < m_listAnswerKor.Length; i++)
            {
                m_listAnswerKor[i].SetActive(true);
                Color clr = Color.white;
                clr.a = fTime;
                m_listAnswerKor[i].GetComponent<SpriteRenderer>().color = clr;
            }

            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < m_listAnswerKor.Length; i++)
        {
            m_listAnswerKor[i].SetActive(true);
            Color clr = Color.white;
            m_listAnswerKor[i].GetComponent<SpriteRenderer>().color = clr;
        }

        for (int i = 0; i < m_listStarKor.Length; i++)
        {
            m_listStarKor[i].SetActive(true);
        }

        float fScale = 1;
        int nDir = 0;

        int nCount = 0;
        while (true)
        {
            if (nDir == 0)
                fScale -= (Time.deltaTime * 1);
            else
                fScale += (Time.deltaTime * 1);

            if (fScale <= -1)
            {
                fScale = -1;
                nDir = 1;
            }
            else if (fScale >= 1)
            {
                fScale = 1;
                nDir = 0;
                nCount++;
            }

            if (nCount >= 2)
                break;

            for (int i = 0; i < m_listStarKor.Length; i++)
            {
                m_listStarKor[i].transform.localScale = new Vector3(fScale, 1, 1);
            }

            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < m_listStarKor.Length; i++)
        {
            m_listStarKor[i].transform.localScale = new Vector3(1, 1, 1);
        }

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

    public void ShowGameBoard(int nIndex)
    {
        m_listGameBoard[nIndex].SetActive(true);
    }

    public void HideAllGameBoard()
    {
        for(int i = 0; i < m_listGameBoard.Length; i++)
        {
            HideGameBoard(i);
        }
    }

    public void HideGameBoard(int nIndex)
    {
        m_listGameBoard[nIndex].SetActive(false);
    }

    public void ShowFrameType(int nIndex)
    {
        HideAllFrameType();
        m_listFrameType[nIndex].SetActive(true);
    }

    public void HideAllFrameType()
    {
        for (int i = 0; i < m_listFrameType.Length; i++)
            m_listFrameType[i].SetActive(false);
    }

    // Scene ------------------------------------------
    public void LoadLobby()
    {
        CGameData.Instance.SetLobbyPage(2);
        SceneManager.LoadScene("Lobby");
    }
    // ------------------------------------------------
}

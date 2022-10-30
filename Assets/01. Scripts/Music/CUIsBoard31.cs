using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

using UnityEngine.UI;

public class CUIsBoard31 : MonoBehaviour
{
    public GameObject m_goUIFrame1Controller;
    public GameObject[] m_listFrame1Stages = new GameObject[4];
    public GameObject m_boardFrame1List;
    public Text[] m_txtFrame1ListTitle = new Text[4];
    public Text m_txtFrame1Title;

    public GameObject[] m_listVideo = new GameObject[4];

    public GameObject m_boardMovieList;
    public Text[] m_txtMovieListTitle = new Text[4];
    public Text m_txtMovieTitle;

    public GameObject m_boardFrame3List;

    private int m_nFrame1Stage = 0;

    private int m_nVideoIndex = 0;
    private int m_nVideoState = 0;

    private int m_nFrame3Index = 0;
    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        InitUI();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitUI()
    {
        UpdateFrame1Title();
        m_boardFrame1List.SetActive(false);

        ShowVidoe(0);

        UpdateMovieTitle();
        HideMovieList();
        HideFrame3List();
    }

    public void OnClickSetup()
    {
        m_nVideoState = 0;
        m_listVideo[m_nVideoIndex].GetComponent<VideoPlayer>().Pause();

        CMusicGameEngine.Instance.ShowSetup();
    }

    public void OnClickReset()
    {
        CMusicGameEngine.Instance.LoadMusicGame();
    }

    // Frame 1-----------------------------------
    public void UpdateFrame1Title()
    {
        m_txtFrame1Title.text = CGameData.Instance.GetBoard31Frame1Title(m_nFrame1Stage);
    }

    public void OnClickFrame1List()
    {
        m_boardFrame1List.SetActive(true);

        for (int i = 0; i < m_txtFrame1ListTitle.Length; i++)
        {
            m_txtFrame1ListTitle[i].text = CGameData.Instance.GetBoard31Frame1Title(i);
        }
    }
    public void OnClickFrame1ListStage(int nIndex)
    {
        m_nFrame1Stage = nIndex;
        m_boardFrame1List.SetActive(false);

        if (m_nFrame1Stage == 0)
            m_goUIFrame1Controller.transform.localPosition = new Vector3(0, -190, 0);
        else
            m_goUIFrame1Controller.transform.localPosition = new Vector3(-550, -300, 0);

        UpdateFrame1Title();
        CMusicGameEngine.Instance.ShowFrame1Stage(m_nFrame1Stage);
    }

    public void OnClickFrame1Play()
    {
        m_listFrame1Stages[m_nFrame1Stage].GetComponent<CUIBoard31Frame1Stage>().PlayDot();
    }

    public void OnClickFrame1Next()
    {
        m_nFrame1Stage++;

        if (m_nFrame1Stage >= CMusicGameEngine.Instance.GetFrame1StageCnt())
            m_nFrame1Stage = 0;

        if (m_nFrame1Stage == 0)
            m_goUIFrame1Controller.transform.localPosition = new Vector3(0, -190, 0);
        else
            m_goUIFrame1Controller.transform.localPosition = new Vector3(-550, -300, 0);

        UpdateFrame1Title();
        CMusicGameEngine.Instance.ShowFrame1Stage(m_nFrame1Stage);
    }

    public void OnClickFrame1Back()
    {
        m_nFrame1Stage--;

        if (m_nFrame1Stage <= 0)
            m_nFrame1Stage = CMusicGameEngine.Instance.GetFrame1StageCnt() - 1;

        if (m_nFrame1Stage == 0)
            m_goUIFrame1Controller.transform.localPosition = new Vector3(0, -190, 0);
        else
            m_goUIFrame1Controller.transform.localPosition = new Vector3(-550, -300, 0);

        UpdateFrame1Title();
        CMusicGameEngine.Instance.ShowFrame1Stage(m_nFrame1Stage);
    }

    public void HideAllVideos()
    {
        for (int i = 0; i < m_listVideo.Length; i++)
        {
            HideVidoe(i);
        }
    }

    public void ShowVidoe(int nIndex)
    {
        m_nVideoIndex = nIndex;
        m_nVideoState = 1;
        HideAllVideos(); 
        m_listVideo[nIndex].gameObject.SetActive(true);
    }

    public void HideVidoe(int nIndex)
    {
        m_listVideo[nIndex].gameObject.SetActive(false);
    }

    public void UpdateMovieTitle()
    {
        m_txtMovieTitle.text = CGameData.Instance.GetMovieTitle(m_nVideoIndex);
    }

    public void ShowMovieList()
    {
        m_boardMovieList.SetActive(true);

        for(int i = 0; i < m_txtMovieListTitle.Length; i++)
        {
            m_txtMovieListTitle[i].text = CGameData.Instance.GetMovieTitle(i);
        }

    }
    public void HideMovieList()
    {
        m_boardMovieList.SetActive(false);
    }

    public void OnClickMovieList()
    {
        ShowMovieList();
    }

    public void OnClickMoveListPlay(int nIndex)
    {
        HideMovieList();

        ShowVidoe(nIndex);

        UpdateMovieTitle();
    }

    public void OnClickPlay()
    {
        if (m_nVideoState == 1)
        {
            m_nVideoState = 0;
            m_listVideo[m_nVideoIndex].GetComponent<VideoPlayer>().Pause();
        } else
        {
            m_nVideoState = 1;
            m_listVideo[m_nVideoIndex].GetComponent<VideoPlayer>().Play();
        }
    }

    public void OnClickNextPlay()
    {
        int nNextIndex = m_nVideoIndex + 1;

        if (nNextIndex >= m_listVideo.Length)
            nNextIndex = 0;

        ShowVidoe(nNextIndex);

        UpdateMovieTitle();
    }

    public void OnClickBackPlay()
    {
        int nBackIndex = m_nVideoIndex - 1;

        if (nBackIndex < 0)
            nBackIndex = (m_listVideo.Length - 1);

        ShowVidoe(nBackIndex);

        UpdateMovieTitle();
    }

    // Frame 3 -----------------------------------
    public void ShowFrame3List()
    {
        m_boardFrame3List.SetActive(true);
    }

    public void HideFrame3List()
    {
        m_boardFrame3List.SetActive(false);
    }

    public void OnClickFrame3List()
    {
        ShowFrame3List();
    }

    public void OnClickFrame3ListPlay(int nIndex)
    {
        HideFrame3List();
        m_nFrame3Index = nIndex;
        CMusicGameEngine.Instance.PlayFrame3(nIndex);
    }

    public void OnClickFrame3Play()
    {
        if (!CMusicGameEngine.Instance.IsFrame3Playing())
        {
            CMusicGameEngine.Instance.PlayFrame3(m_nFrame3Index);
        }
        else
        {
            if (CMusicGameEngine.Instance.GetFrame3Speed() > 0)
                CMusicGameEngine.Instance.SetFrame3Speed(0);
            else
                CMusicGameEngine.Instance.SetFrame3Speed(3);
        }
    }

    public void OnClickFrame3Next()
    {
        m_nFrame3Index++;
        if (m_nFrame3Index >= 8)
            m_nFrame3Index = 0;

        CMusicGameEngine.Instance.PlayFrame3(m_nFrame3Index);
    }

    public void OnClickFrame3Back()
    {
        m_nFrame3Index--;
        if (m_nFrame3Index <= 0)
            m_nFrame3Index = 7;

        CMusicGameEngine.Instance.PlayFrame3(m_nFrame3Index);
    }
    
    public void OnClickPlayFrame3()
    {
        if (!CMusicGameEngine.Instance.IsFrame3Playing())
        {
            Debug.Log("Playing!!!");
            CMusicGameEngine.Instance.PlayFrame3(m_nFrame3Index);
        }
        else
        {
            if (CMusicGameEngine.Instance.GetFrame3Speed() > 0)
                CMusicGameEngine.Instance.SetFrame3Speed(0);
            else
                CMusicGameEngine.Instance.SetFrame3Speed(3);
        }
    }

    public void OnClickPlayFrame4()
    {
        if(!CMusicGameEngine.Instance.IsFrame4Playing())
            CMusicGameEngine.Instance.PlayFrame4();
        else
        {
            if (CMusicGameEngine.Instance.GetFrame4Speed() > 0)
                CMusicGameEngine.Instance.SetFrame4Speed(0);
            else
                CMusicGameEngine.Instance.SetFrame4Speed(1);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

public class CUIsBoard31 : MonoBehaviour
{
    public GameObject[] m_listVideo = new GameObject[4];

    private int m_nFrame1Stage = 0;

    private int m_nVideoIndex = 0;
    private int m_nVideoState = 0;
    // Start is called before the first frame update
    void Start()
    {
        InitUI();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitUI()
    {
        ShowVidoe(0);
    }

    public void OnClickFrame1Next()
    {
        m_nFrame1Stage++;

        if (m_nFrame1Stage >= CMusicGameEngine.Instance.GetFrame1StageCnt())
            m_nFrame1Stage = 0;

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
    }

    public void OnClickBackPlay()
    {
        int nBackIndex = m_nVideoIndex - 1;

        if (nBackIndex < 0)
            nBackIndex = (m_listVideo.Length - 1);

        ShowVidoe(nBackIndex);
    }

    public void OnClickPlayFrame3()
    {
        if (!CMusicGameEngine.Instance.IsFrame3Playing())
            CMusicGameEngine.Instance.PlayFrame3();
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

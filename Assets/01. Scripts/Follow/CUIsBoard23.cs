using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsBoard23 : MonoBehaviour
{
    public GameObject m_goLeftMissionButtion;
    public GameObject[] m_listLeftMission = new GameObject[3];

    public GameObject m_goRightMissionButtion;
    public GameObject[] m_listRightMission = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        HideAllLeftMission();
        HideAllRightMission();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAllLeftMission()
    {
        for(int i = 0; i < m_listLeftMission.Length; i++)
        {
            m_listLeftMission[i].SetActive(false);
        }
    }

    public void ShowLeftMission(int nIndex)
    {
        HideAllLeftMission();
        m_listLeftMission[nIndex].SetActive(true);
    }

    public void HideAllRightMission()
    {
        for (int i = 0; i < m_listRightMission.Length; i++)
        {
            m_listRightMission[i].SetActive(false);
        }
    }

    public void ShowRightMission(int nIndex)
    {
        HideAllRightMission();
        m_listRightMission[nIndex].SetActive(true);
    }

    public void OnClickLeftMission(int nIndex)
    {
        m_goLeftMissionButtion.SetActive(false);
        ShowLeftMission(nIndex);
    }

    public void OnClickLeftMissionReset()
    {
        HideAllLeftMission();
        m_goLeftMissionButtion.SetActive(true);
    }

    public void OnClickRightMission(int nIndex)
    {
        m_goRightMissionButtion.SetActive(false);
        ShowRightMission(nIndex);
    }

    public void OnClickRightMissionReset()
    {
        HideAllRightMission();
        m_goRightMissionButtion.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsBoard24 : MonoBehaviour
{
    public GameObject m_goLeftButton;
    public GameObject m_goLeftMissionCommon;
    public GameObject[] m_listLeftMission = new GameObject[4];

    public GameObject m_goRightButton;
    public GameObject[] m_listRightMission = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        HideAllLeftMission();
        m_goLeftButton.SetActive(true);

        HideAllRightMission();
        m_goRightButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAllLeftMission()
    {
        m_goLeftMissionCommon.SetActive(false);

        for(int i = 0; i < m_listLeftMission.Length; i++)
        {
            m_listLeftMission[i].SetActive(false);
        }
    }

    public void ShowLeftMission(int nIndex)
    {
        m_goLeftMissionCommon.SetActive(true);
        m_listLeftMission[nIndex].SetActive(true);
    }

    public void OnClickLeftMission(int nIndex)
    {
        m_goLeftButton.SetActive(false);
        ShowLeftMission(nIndex);
    }

    public void OnClickLeftMissionReset()
    {
        HideAllLeftMission();
        m_goLeftButton.SetActive(true);
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
        m_listRightMission[nIndex].SetActive(true);
    }

    public void OnClickRightMission(int nIndex)
    {
        m_goRightButton.SetActive(false);
        ShowRightMission(nIndex);
    }

    public void OnClickRightMissionReset()
    {
        HideAllRightMission();
        m_goRightButton.SetActive(true);
    }
}

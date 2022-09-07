using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsBoard25 : MonoBehaviour
{
    public GameObject m_goButtons;
    public GameObject[] m_listMission = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        HideAllMission();
        m_goButtons.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAllMission()
    {
        for(int i = 0; i < m_listMission.Length; i++)
        {
            m_listMission[i].SetActive(false);
        }
    }

    public void ShowMission(int nIndex)
    {
        HideAllMission();
        m_listMission[nIndex].SetActive(true);
    }

    public void OnClickMission(int nIndex)
    {
        m_goButtons.SetActive(false);
        ShowMission(nIndex);
    }

    public void OnClickMissionReset()
    {
        m_goButtons.SetActive(true);
        HideAllMission();
    }
}

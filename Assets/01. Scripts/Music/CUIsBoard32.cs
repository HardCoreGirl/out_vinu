using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsBoard32 : MonoBehaviour
{
    public GameObject[] m_listStages = new GameObject[7];

    private int m_nStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        ShowStage(m_nStage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSetup()
    {
        CMusicGameEngine.Instance.ShowSetup();
    }

    public void OnClickBack()
    {
        m_nStage--;

        if (m_nStage <= 0)
            m_nStage = m_listStages.Length - 1;

        ShowStage(m_nStage);
    }

    public void OnClickNext()
    {
        m_nStage++;

        if (m_nStage >= m_listStages.Length )
            m_nStage = 0;

        ShowStage(m_nStage);
    }

    public void OnClickReset()
    {
        m_listStages[m_nStage].GetComponent<CUIBoard32StageManager>().ResetBoard();
    }

    public void HideAllStages()
    {
        for(int i = 0; i < m_listStages.Length; i++)
            HideStage(i);
    }

    public void ShowStage(int nIndex)
    {
        HideAllStages();
        m_listStages[nIndex].gameObject.SetActive(true);
    }

    public void HideStage(int nIndex)
    {
        m_listStages[nIndex].gameObject.SetActive(false);
    }
}

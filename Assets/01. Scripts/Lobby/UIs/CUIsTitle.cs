using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsTitle : MonoBehaviour
{
    public GameObject m_goIdle;
    public GameObject m_goStart;
    public GameObject m_goTutorial;
    public GameObject m_goTutorialObject;

    public GameObject m_goUICommon;

    // Start is called before the first frame update
    void Start()
    {
        m_goUICommon.SetActive(false);

        m_goIdle.SetActive(true);
        m_goStart.SetActive(false);
        m_goTutorial.SetActive(false);
        m_goTutorialObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        m_goTutorialObject.SetActive(false);
        m_goUICommon.SetActive(true);
        CLobbyManager.Instance.ShowUIs(1);
    }

    public void OnClickIdleNext()
    {
        m_goIdle.SetActive(false);
        m_goStart.SetActive(true);
        m_goTutorial.SetActive(false);
    }

    public void OnClickStartNext()
    {
        m_goIdle.SetActive(false);
        m_goStart.SetActive(false);
        m_goTutorial.SetActive(true);
        m_goTutorialObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsMainMenu : MonoBehaviour
{
    public GameObject m_goBtnHome;

    // Start is called before the first frame update
    void Start()
    {
        m_goBtnHome.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickMode(int nIndex)
    {
        m_goBtnHome.SetActive(true);

        int nUIIndex = nIndex + 2;

        CLobbyManager.Instance.ShowUIs(nUIIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsLobbySetup : MonoBehaviour
{
    public GameObject m_goBtnSetup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickExit()
    {
        CLobbyManager.Instance.HideSetup();
        CLobbyManager.Instance.ShowUIs(1);
        m_goBtnSetup.SetActive(true);
    }
}

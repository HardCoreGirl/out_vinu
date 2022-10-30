using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsLobbyCommon : MonoBehaviour
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

    public void OnClickHome()
    {
        CLobbyManager.Instance.ShowUIs(1);
    }

    public void OnClickSetting()
    {
        //CGameData.Instance.SetStage(99999999);
        //CLobbyManager.Instance.LoadInGame();
        CLobbyManager.Instance.ShowUIs(6);
        CLobbyManager.Instance.ShowSetup();

        m_goBtnSetup.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CUISetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickHome()
    {
        CGameData.Instance.SetLobbyPage(1);
        SceneManager.LoadScene("Lobby");
    }
}

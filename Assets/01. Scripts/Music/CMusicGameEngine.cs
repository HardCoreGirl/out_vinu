using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CMusicGameEngine : MonoBehaviour
{
    #region SingleTon
    public static CMusicGameEngine _instance = null;

    public static CMusicGameEngine Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CMusicGameEnginee install null");

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            _instance = null;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNext()
    {
        int nStage = CGameData.Instance.GetStage() + 1;
        //if (nStage > 32003)
        if (nStage > 32004)
        {
            LoadHome();
            return;
        }

        CGameData.Instance.SetStage(nStage);
        LoadMusicGame();
    }

    public void LoadMusicGame()
    {
        SceneManager.LoadScene("Music");
    }

    public void LoadHome()
    {
        CGameData.Instance.SetLobbyPage(1);
        SceneManager.LoadScene("Lobby");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsGridMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay(int nStage)
    {
        CGameData.Instance.SetStage(nStage);
        CLobbyManager.Instance.LoadInGame();
    }
}

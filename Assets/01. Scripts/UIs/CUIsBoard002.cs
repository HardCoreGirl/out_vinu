using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsBoard002 : MonoBehaviour
{
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
        if (CGameEngine.Instance.GetGameStep() == 1)
        {
            CGameEngine.Instance.SetGameStep(2);

            Debug.Log("Stage : " + CGameData.Instance.GetStage());

            if (CGameData.Instance.GetStage() == 1000)
                CGameEngine.Instance.ShowBoard002Answer();
            else if (CGameData.Instance.GetStage() == 2000)
                CGameEngine.Instance.ShowGridKorAnswer();
            //ShowAnswer();
            //CGameEngine.Instance.ShowTutorial(0);
            //ShowBtnsTutoialAll();

            //if (CGameData.Instance.GetStage() == 0)
            //    CGameEngine.Instance.ShowAnswerTile(0, 0);
            //else if (CGameData.Instance.GetStage() == 1)
            //    CGameEngine.Instance.ShowAnswerTile(1, 1);
            //else if (CGameData.Instance.GetStage() == 2)
            //    CGameEngine.Instance.ShowAnswerTile(1, 0);
            //else if (CGameData.Instance.GetStage() == 3)
            //    CGameEngine.Instance.ShowAnswerTile(2, 1);
            //else if (CGameData.Instance.GetStage() == 4)
            //    CGameEngine.Instance.ShowAnswerTile(3, 1);
            //else if (CGameData.Instance.GetStage() == 5)
            //    CGameEngine.Instance.ShowAnswerTile(3, 2);
            //else if (CGameData.Instance.GetStage() == 6)
            //    CGameEngine.Instance.ShowAnswerTile(4, 2);
            //else if (CGameData.Instance.GetStage() == 7)
            //    CGameEngine.Instance.ShowAnswerTile(3, 3);
            //else if (CGameData.Instance.GetStage() == 8)
            //    CGameEngine.Instance.ShowAnswerTile(4, 3);


        }
        else if (CGameEngine.Instance.GetGameStep() == 2)
        {
            CGameEngine.Instance.LoadLobby();
            //CGameEngine.Instance.SetGameStep(3);
            //ShowFinishMenu();
        }
        else
        {
            //SceneManager.LoadScene("InGame");
        }

    }
}

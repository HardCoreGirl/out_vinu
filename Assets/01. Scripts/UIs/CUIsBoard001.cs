using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class CUIsBoard001 : MonoBehaviour
{
    public GameObject m_goBtnNext;

    public GameObject m_goAnswer;
    public GameObject[] m_listAnswerBoard = new GameObject[2];
    public Text[] m_listAnswer = new Text[2];

    public GameObject m_goFinishMenu;

    public GameObject[] m_listQuiz = new GameObject[9];

    public GameObject[] m_listBtnsTutorial = new GameObject[4];

    public GameObject[] m_listAnswerPic = new GameObject[6];

    //public VideoPlayer[] m_listTutorialMath = new VideoPlayer[4];

    // Start is called before the first frame update
    void Start()
    {
        //HideBtnsTutorial();
        HideBtnsTutorialAll();
        HideFinishMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickNext()
    {
        Debug.Log("OnClickNext : " + CGameEngine.Instance.GetGameStep());
        if(CGameEngine.Instance.GetGameStep() == 1)
        {
            CGameEngine.Instance.SetGameStep(2);
            ShowAnswer();
            CGameEngine.Instance.ShowTutorial(0);
            ShowBtnsTutoialAll();

            if (CGameData.Instance.GetStage() == 0)
                CGameEngine.Instance.ShowAnswerTile(0, 0);
            else if (CGameData.Instance.GetStage() == 1)
                CGameEngine.Instance.ShowAnswerTile(1, 1);
            else if (CGameData.Instance.GetStage() == 2)
                CGameEngine.Instance.ShowAnswerTile(1, 0);
            else if (CGameData.Instance.GetStage() == 3)
                CGameEngine.Instance.ShowAnswerTile(2, 1);
            else if (CGameData.Instance.GetStage() == 4)
                CGameEngine.Instance.ShowAnswerTile(3, 1);
            else if (CGameData.Instance.GetStage() == 5)
                CGameEngine.Instance.ShowAnswerTile(3, 2);
            else if (CGameData.Instance.GetStage() == 6)
                CGameEngine.Instance.ShowAnswerTile(4, 2);
            else if (CGameData.Instance.GetStage() == 7)
                CGameEngine.Instance.ShowAnswerTile(3, 3);
            else if (CGameData.Instance.GetStage() == 8)
                CGameEngine.Instance.ShowAnswerTile(4, 3);


        } else if (CGameEngine.Instance.GetGameStep() == 2)
        {
            CGameEngine.Instance.SetGameStep(3);
            ShowFinishMenu();
        }
        else
        {
            //SceneManager.LoadScene("InGame");
        }
        

     
    }

    public void OnClickPlayTutorial(int nIndex)
    {
        CGameEngine.Instance.PlayerTutorialVideo(nIndex);
        StartCoroutine(ProcessPlayTutorial(nIndex));
    }

    public void OnClickReplay()
    {
        
        SceneManager.LoadScene("InGame");
    }

    public void OnClickNextStage()
    {
        int nStage = CGameData.Instance.GetStage() + 1;

        if (nStage >= 9)
            nStage = 0;

        CGameData.Instance.SetStage(nStage);
        Debug.Log(CGameData.Instance.GetStage());
        SceneManager.LoadScene("InGame");
    }

    IEnumerator ProcessPlayTutorial(int nIndex)
    {
        HideBtnsTutorial(nIndex);
        yield return new WaitForSeconds(7f);
        ShowBtnsTutorial(nIndex);
    }

    public void ShowBtnsNext()
    {
        m_goBtnNext.SetActive(true);
    }
    public void HideBtnsNext()
    {
        m_goBtnNext.SetActive(false);
    }

    public void ShowAnswer()
    {
        m_goAnswer.SetActive(true);

        for(int i = 0; i < m_listAnswerPic.Length; i++)
            m_listAnswerPic[i].SetActive(false);

        if (CGameData.Instance.GetStage() == 0)
            UpdateAnswer("7");
        else if (CGameData.Instance.GetStage() == 1)
            UpdateAnswer("6");
        else if (CGameData.Instance.GetStage() == 2)
            UpdateAnswer("9");
        else if (CGameData.Instance.GetStage() == 3)
            UpdateAnswer("P");
        else if (CGameData.Instance.GetStage() == 4)
            UpdateAnswer("H");
        else if (CGameData.Instance.GetStage() == 5)
            UpdateAnswer("A");
        else if (CGameData.Instance.GetStage() == 6)
        {
            UpdateAnswer("");
            m_listAnswerPic[0].SetActive(true);
            m_listAnswerPic[1].SetActive(true);
        }
        else if (CGameData.Instance.GetStage() == 7)
        {
            UpdateAnswer("");
            m_listAnswerPic[2].SetActive(true);
            m_listAnswerPic[3].SetActive(true);

        }
        else if (CGameData.Instance.GetStage() == 8)
        {
            UpdateAnswer("");
            m_listAnswerPic[4].SetActive(true);
            m_listAnswerPic[5].SetActive(true);
        }

        StartCoroutine("ProcessShowAnswer");
    }

    IEnumerator ProcessShowAnswer()
    {
        m_listAnswerBoard[0].transform.localScale = new Vector3(0, 0, 0);
        m_listAnswerBoard[1].transform.localScale = new Vector3(0, 0, 0);
        float fScale = 0;
        while(true)
        {
            fScale += (Time.deltaTime * CGameData.Instance.GetAnswerSpeed());

            if (fScale >= 1)
                break;

            m_listAnswerBoard[0].transform.localScale = new Vector3(fScale, fScale, fScale);
            m_listAnswerBoard[1].transform.localScale = new Vector3(fScale, fScale, fScale);

            yield return new WaitForEndOfFrame();
        }

        m_listAnswerBoard[0].transform.localScale = new Vector3(1, 1, 1);
        m_listAnswerBoard[1].transform.localScale = new Vector3(1, 1, 1);
    }

    public void HideAnswer()
    {
        m_goAnswer.SetActive(false);
    }

    public void UpdateAnswer(string strAnswer)
    {
        for (int i = 0; i < m_listAnswer.Length; i++)
            m_listAnswer[i].text = strAnswer;
    }

    public void ShowQuiz(int nIndex)
    {
        HideAllQuiz();
        m_listQuiz[nIndex].SetActive(true);
    }
    public void HideQuiz(int nIndex)
    {
        m_listQuiz[nIndex].SetActive(false);
    }

    public void HideAllQuiz()
    {
        for(int i = 0; i < m_listQuiz.Length; i++)
        {
            HideQuiz(i);
        }
    }

    public void ShowBtnsTutorial(int nIndex)
    {
        m_listBtnsTutorial[nIndex].SetActive(true);
    }

    public void HideBtnsTutorial(int nIndex)
    {
        m_listBtnsTutorial[nIndex].SetActive(false);
    }

    public void ShowBtnsTutoialAll()
    {
        for (int i = 0; i < m_listBtnsTutorial.Length; i++)
        {
            ShowBtnsTutorial(i);
        }
    }

    public void HideBtnsTutorialAll()
    {
        for(int i = 0; i < m_listBtnsTutorial.Length; i++)
        {
            HideBtnsTutorial(i);
        }
    }

    public void ShowFinishMenu()
    {
        m_goFinishMenu.SetActive(true);
    }

    public void HideFinishMenu()
    {
        m_goFinishMenu.SetActive(false);
    }
}


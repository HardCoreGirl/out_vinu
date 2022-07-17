using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CUIsBoard001 : MonoBehaviour
{
    public GameObject m_goBtnNext;

    public GameObject m_goAnswer;

    public GameObject[] m_listQuizMath = new GameObject[2];

    public GameObject[] m_listBtnsTutorial = new GameObject[4];

    //public VideoPlayer[] m_listTutorialMath = new VideoPlayer[4];

    // Start is called before the first frame update
    void Start()
    {
        //HideBtnsTutorial();
        HideBtnsTutorialAll();
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

            CGameEngine.Instance.ShowAnswerTile(0, 0);
        } else
        {
            SceneManager.LoadScene("InGame");
        }
        

     
    }

    public void OnClickPlayTutorial(int nIndex)
    {
        CGameEngine.Instance.PlayerTutorialVideo(nIndex);
        StartCoroutine(ProcessPlayTutorial(nIndex));
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
    }
    public void HideAnswer()
    {
        m_goAnswer.SetActive(false);
    }

    public void ShowQuiz(int nIndex)
    {
        HideAllQuiz();
        m_listQuizMath[nIndex].SetActive(true);
    }
    public void HideQuiz(int nIndex)
    {
        m_listQuizMath[nIndex].SetActive(false);
    }

    public void HideAllQuiz()
    {
        for(int i = 0; i < m_listQuizMath.Length; i++)
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
}

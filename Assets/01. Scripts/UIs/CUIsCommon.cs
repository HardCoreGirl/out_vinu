using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CUIsCommon : MonoBehaviour
{
    public GameObject[] m_listQuiz = new GameObject[1];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuiz(int nIndex)
    {
        HideAllQuiz();

        int nQuiz = nIndex;

        if( nIndex == 1000 )
        {
            nQuiz = 9;
        } else if (nIndex == 2000)
        {
            nQuiz = 10;
        }

        m_listQuiz[nQuiz].SetActive(true);
    }
    public void HideQuiz(int nIndex)
    {
        m_listQuiz[nIndex].SetActive(false);
    }

    public void HideAllQuiz()
    {
        for (int i = 0; i < m_listQuiz.Length; i++)
        {
            HideQuiz(i);
        }
    }

    public void OnClickHome()
    {
        CGameEngine.Instance.LoadLobby();
    }

    public void OnClickReset()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnClickSetup()
    {
        SceneManager.LoadScene("Setup");
    }
}

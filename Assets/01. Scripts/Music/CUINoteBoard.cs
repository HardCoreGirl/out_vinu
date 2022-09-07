using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CUINoteBoard : MonoBehaviour
{
    public Text m_txtTitle;
    public GameObject[] m_listNoteBoard = new GameObject[2];
    public GameObject[] m_listNote = new GameObject[13];
    public GameObject[] m_listNoteB = new GameObject[13];

    private int m_nCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        int nStage = CGameData.Instance.GetStage() - 32000;

        int[] listSong = CGameData.Instance.GetSong(nStage - 1);
        string[] listLyrics = CGameData.Instance.GetLyric(nStage - 1);

        float fInterval = 0;
        fInterval = 129;    // 13개
        fInterval = 138;    // 12개
        fInterval = 168;    // 12개
        fInterval = 216;    // 12개
        m_nCount = listSong.Length;

        if (m_nCount == 8) fInterval = 216;
        else if (m_nCount == 10) fInterval = 168;
        else if (m_nCount == 12) fInterval = 138;
        else if (m_nCount == 13) fInterval = 129;
        else if (m_nCount == 20) fInterval = 168;

        Debug.Log("Count : " + m_nCount);

        m_txtTitle.text = CGameData.Instance.GetSongTitle(nStage - 1);
        if (m_nCount < 13)
        {
            m_listNoteBoard[1].SetActive(false);
            for (int i = 0; i < m_listNote.Length; i++)
            {
                if (i < m_nCount)
                {
                    m_listNote[i].transform.localPosition = new Vector3((200 + fInterval * i), 0, 0);
                    if ((m_nCount - 1 == i))
                        m_listNote[i].GetComponent<CUINote>().InitNote(listSong[i], fInterval, listLyrics[i], true);
                    else
                        m_listNote[i].GetComponent<CUINote>().InitNote(listSong[i], fInterval, listLyrics[i]);
                }
                else
                {
                    m_listNote[i].SetActive(false);
                }
            }
        } else
        {
            m_listNoteBoard[0].SetActive(true);
            m_listNoteBoard[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(200, 250);
            m_listNoteBoard[0].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            for (int i = 0; i < m_listNote.Length; i++)
            {
                if (i < m_nCount / 2 )
                {
                    m_listNote[i].transform.localPosition = new Vector3((200 + fInterval * i), 0, 0);
                    if ((m_nCount - 1 == i))
                        m_listNote[i].GetComponent<CUINote>().InitNote(listSong[i], fInterval, listLyrics[i], true);
                    else
                        m_listNote[i].GetComponent<CUINote>().InitNote(listSong[i], fInterval, listLyrics[i]);
                }
                else
                {
                    m_listNote[i].SetActive(false);
                }
            }
            m_listNoteBoard[1].SetActive(true);
            m_listNoteBoard[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(200, -150);
            m_listNoteBoard[1].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            for (int i = 0; i < m_listNoteB.Length; i++)
            {
                if (i < m_nCount / 2)
                {
                    m_listNoteB[i].transform.localPosition = new Vector3((200 + fInterval * i), 0, 0);
                    if ((m_nCount - 1 == i))
                        m_listNoteB[i].GetComponent<CUINote>().InitNote(listSong[i], fInterval, listLyrics[i], true);
                    else
                        m_listNoteB[i].GetComponent<CUINote>().InitNote(listSong[i], fInterval, listLyrics[i]);
                }
                else
                {
                    m_listNoteB[i].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickClear()
    {
        for (int i = 0; i < m_listNote.Length; i++)
        {
            m_listNote[i].GetComponent<CUINote>().NoSelected();
        }

        if (m_nCount > 13)
        {
            for (int i = 0; i < m_listNoteB.Length; i++)
            {
                    m_listNoteB[i].GetComponent<CUINote>().NoSelected();
            }
        }
    }
}

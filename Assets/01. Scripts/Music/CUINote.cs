using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class CUINote : MonoBehaviour
{

    public GameObject m_goNote;

    public GameObject[] m_listBtnNote = new GameObject[8];
    public GameObject m_goBlack;
    public GameObject m_goSelected;
    public Text m_txtNoteIndex;
    public Text m_txtLyric;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitNote(int nNoteIndex, float fInterval, string strLyrics, bool bIsFinish = false)
    {
        //float fInterval = 72;
        float fColorInterval = fInterval / 3;
        float fXPoz = 0;
        float fYPoz = 0;
        if (m_goNote != null)
        {
            m_goNote.GetComponent<Image>().color = CGameData.Instance.GetColor(nNoteIndex);
            m_goNote.GetComponent<RectTransform>().localPosition = new Vector3(0, -36 + ((nNoteIndex - 1)* 14), 0);

            m_txtLyric.text = strLyrics;

            if( nNoteIndex == 1 ) m_txtNoteIndex.text = "도";
            else if (nNoteIndex == 2) m_txtNoteIndex.text = "레";
            else if (nNoteIndex == 3) m_txtNoteIndex.text = "미";
            else if (nNoteIndex == 4) m_txtNoteIndex.text = "파";
            else if (nNoteIndex == 5) m_txtNoteIndex.text = "솔";
            else if (nNoteIndex == 6) m_txtNoteIndex.text = "라";
            else if (nNoteIndex == 7) m_txtNoteIndex.text = "시";
            else if (nNoteIndex == 8) m_txtNoteIndex.text = "도";

            for (int i = 0; i < m_listBtnNote.Length; i++)
            {
                m_listBtnNote[i].GetComponent<RectTransform>().sizeDelta = new Vector2(fColorInterval, fColorInterval);

                //if( (i % 2) == 0)
                //{
                    fXPoz = (fColorInterval * (i % 2)) - ((fColorInterval / 2));
                //}
                
                fYPoz = -200 - (fColorInterval * (int)(i / 2));
                m_listBtnNote[i].GetComponent<RectTransform>().localPosition = new Vector3(fXPoz, fYPoz, 0);
                m_listBtnNote[i].GetComponent<Image>().color = CGameData.Instance.GetMusicBlockColor(i);
            }

            if (!bIsFinish)
            {
                m_goBlack.GetComponent<RectTransform>().sizeDelta = new Vector2(fColorInterval, fColorInterval * 4);
                m_goBlack.GetComponent<RectTransform>().localPosition = new Vector3(fColorInterval + (fColorInterval / 2), -200 - (fColorInterval * 1.5f), 0);
            } else
            {
                m_goBlack.SetActive(false);
            }

            m_goSelected.GetComponent<RectTransform>().sizeDelta = new Vector2(fColorInterval * 2, fColorInterval * 4);
            //m_goSelected.GetComponent<RectTransform>().localPosition = new Vector3(-fInterval, -200 - (fInterval * 1.5f), 0);
            m_goSelected.GetComponent<RectTransform>().localPosition = new Vector3(0, -200 - (fColorInterval * 1.5f), 0);
            m_goSelected.SetActive(false);
        }
    }

    public void OnClickColor(int nIndex)
    {
        m_goSelected.SetActive(true);
        m_goSelected.GetComponent<Image>().color = CGameData.Instance.GetColor(nIndex);
    }

    public void NoSelected()
    {
        m_goSelected.SetActive(false);
    }
}

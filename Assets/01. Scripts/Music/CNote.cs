using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNote : MonoBehaviour
{
    public GameObject m_goTest01;
    public GameObject m_goTest02;
    public GameObject m_goTest03;

    public GameObject[] m_goNoteBlock = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitNote(float fXPoz, int nNoteIndex)
    {
        //Vector3 vecPoz = transform.localPosition;
        //vecPoz.x = fXPoz;
        //transform.localPosition = vecPoz;

        float fBlockXPoz = 0;
        float fBlockYPoz = 0;

        // 8개
        float fSize = 2.3f;
        float fPoz = -0.368f;

        /*
        // 10개
        float fSize = 1.75f;
        float fPoz = -0.279f;
        */
        /*
        // 12개
        float fSize = 1.45f;
        float fPoz = -0.23f;
        *
/*
        // 13개
        float fSize = 1.37f;
        float fPoz = -0.219f;
*/
        for (int i =0; i < m_goNoteBlock.Length; i++)
        {
            if (m_goNoteBlock[i] != null)
            {
                m_goNoteBlock[i].transform.localScale = new Vector3(fSize, fSize, fSize);

                
                if( (i % 2) == 0 )
                {
                    fBlockXPoz = fPoz;
                } else
                {
                    fBlockXPoz = fPoz * -1;
                }

                int nYIndex = (int)(i / 2);


                m_goNoteBlock[i].transform.localPosition = new Vector3(fBlockXPoz, nYIndex * (fPoz * 2), 0);
                m_goNoteBlock[i].GetComponent<SpriteRenderer>().color = CGameData.Instance.GetMusicBlockColor(i);


            }
        }
        /*
        if (m_goTest01 != null)
        {
            m_goTest01.transform.localScale = new Vector3(fSize, fSize, fSize);
            m_goTest01.transform.localPosition = new Vector3(fPoz, 0, 0);
        }

        if (m_goTest02 != null)
        {
            m_goTest02.transform.localScale = new Vector3(fSize, fSize, fSize);
            m_goTest02.transform.localPosition = new Vector3(fPoz * -1, 0, 0);
        }

        if (m_goTest03 != null)
        {
            m_goTest03.transform.localScale = new Vector3(fSize, fSize, fSize);
            m_goTest03.transform.localPosition = new Vector3((fPoz * -1)*3, 0, 0);
        }
        */
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMusicManager : MonoBehaviour
{

    public GameObject[] m_listNote = new GameObject[13];

    public GameObject m_goBlack;

    // Start is called before the first frame update
    void Start()
    {
        //CGameData.Instance.InitGameData();

        //UpdateMusic();



        //float fInterval = 15f / 7;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMusic()
    {
        int[] listSong = CGameData.Instance.GetSong(0);
        float[] listNotePoz = CGameData.Instance.GetNotePoz(13);
        float fInterval = 15f / (float)(listSong.Length - 1);

        for (int i = 0; i < m_listNote.Length; i++)
        {
            if (listSong.Length > i)
            {
                m_listNote[i].SetActive(true);
                m_listNote[i].transform.localPosition = new Vector3(-7.5f + (fInterval * i), 0, 0);
                m_listNote[i].GetComponent<CNote>().InitNote(listNotePoz[i], 0);
            }
            else
                m_listNote[i].SetActive(false);
        }

        m_goBlack.transform.localScale = new Vector3(50f, 2.3f * 4, 1);
        m_goBlack.transform.localPosition = new Vector3(0, -3.11f, 0);
    }
}

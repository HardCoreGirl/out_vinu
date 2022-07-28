using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsTest02 : MonoBehaviour
{
    public GameObject[] m_listBoard = new GameObject[2];

    private int m_nPage = 0;

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
        m_nPage++;

        if (m_nPage >= 2) m_nPage = 0;

        HideAllBoard();

        m_listBoard[m_nPage].gameObject.SetActive(true);
    }

    public void HideAllBoard()
    {
        for(int i = 0; i < m_listBoard.Length; i++)
        {
            m_listBoard[i].gameObject.SetActive(false);
        }
    }
}

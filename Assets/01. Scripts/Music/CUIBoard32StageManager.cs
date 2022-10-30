using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIBoard32StageManager : MonoBehaviour
{
    public GameObject[] m_listBoard = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBoard()
    {
        for(int i = 0; i < m_listBoard.Length; i++)
        {
            m_listBoard[i].GetComponent<CUIBoard32BtnsManager>().OnClickReset();
        }    
    }
}

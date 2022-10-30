using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIBoard32BtnsManager : MonoBehaviour
{
    public GameObject[] m_listBtns = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickReset()
    {
        for(int i = 0; i < m_listBtns.Length; i++)
        {
            m_listBtns[i].GetComponent<CUIBoard32Btns>().ResetColor();
        }
    }
}

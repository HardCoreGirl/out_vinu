using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIBoard31Frame1Stage : MonoBehaviour
{
    public GameObject[] m_listDot = new GameObject[20];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDot()
    {
        for(int i = 0; i < m_listDot.Length; i++)
        {
            m_listDot[i].GetComponent<CDotNote>().PlayDot();
        }
    }
    
}

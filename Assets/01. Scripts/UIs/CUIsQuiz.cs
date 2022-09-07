using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsQuiz : MonoBehaviour
{
    private float m_fScale = 1;
    private int m_nDir = 0;

    private float m_fSpeed = 0.1f;
    private float m_fSize = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( m_nDir == 0)
            m_fScale += (Time.deltaTime * m_fSpeed);
        else
            m_fScale -= (Time.deltaTime * m_fSpeed);

        if (m_fScale > (1 + m_fSize))
            m_nDir = 1;
        else if (m_fScale < (1 - m_fSize))
            m_nDir = 0;

        gameObject.transform.localScale = new Vector3(m_fScale, m_fScale, m_fScale);
    }
}

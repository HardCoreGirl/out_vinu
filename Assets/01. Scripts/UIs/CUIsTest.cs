using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CUIsTest : MonoBehaviour
{
    public GameObject[] m_listTestPartBlock = new GameObject[4];
    public GameObject m_listTestBlock;

    public Text m_txtScale;
    public Text m_txtPartScale;

    private int m_nIndex = 0;
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
        m_nIndex++;

        if (m_nIndex >= 6)
            m_nIndex = 0;

        CGameEngine.Instance.HideAllTestBG();
        CGameEngine.Instance.ShowTestBG(m_nIndex);
    }

    public void OnClickAllChangeScale(int nIndex)
    {
        Vector3 vecScale = m_listTestBlock.transform.localScale;
        if( nIndex == 0)
            vecScale += new Vector3(0.001f, 0.001f, 0.001f);
        else if ( nIndex == 1)
            vecScale -= new Vector3(0.001f, 0.001f, 0.001f);
        else if (nIndex == 2)
            vecScale += new Vector3(0.01f, 0.01f, 0.01f);
        else if (nIndex == 3)
            vecScale -= new Vector3(0.01f, 0.01f, 0.01f);

        m_txtScale.text = vecScale.x.ToString();
        m_listTestBlock.transform.localScale = vecScale;
    }

    public void OnClickPartChangeScale(int nIndex)
    {
        Vector3 vecScale = m_listTestPartBlock[0].transform.localScale;
        if (nIndex == 0)
            vecScale += new Vector3(0.001f, 0.001f, 0.001f);
        else if (nIndex == 1)
            vecScale -= new Vector3(0.001f, 0.001f, 0.001f);
        else if (nIndex == 2)
            vecScale += new Vector3(0.01f, 0.01f, 0.01f);
        else if (nIndex == 3)
            vecScale -= new Vector3(0.01f, 0.01f, 0.01f);

        m_txtPartScale.text = vecScale.x.ToString();

        for(int i = 0; i < m_listTestPartBlock.Length; i++)
        {
            m_listTestPartBlock[i].transform.localScale = vecScale;
        }
        
    }
}


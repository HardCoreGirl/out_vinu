using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CUIsBtnColor : MonoBehaviour
{
    public GameObject m_goColor;
    public GameObject m_goSelector;

    private int m_nPlayerIndex;
    private int m_nIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitItem(int nPlayerIndex, int nIndex)
    {
        Debug.Log("InitItem");
        m_nPlayerIndex = nPlayerIndex;
        m_nIndex = nIndex;
        m_goColor.GetComponent<Image>().color = CGameData.Instance.GetColor(nIndex);
        if( nIndex == 0 )
            m_goSelector.SetActive(true);
        else
            m_goSelector.SetActive(false);
    }

    public void UpdateItem()
    {
        if(CEmoGameEngine.Instance.GetSelectorColor(m_nPlayerIndex) == m_nIndex)
            m_goSelector.SetActive(true);
        else
            m_goSelector.SetActive(false);
    }

    public void OnClickColor()
    {
        CEmoGameEngine.Instance.SetSelectColor(m_nPlayerIndex, m_nIndex);
        CEmoGameEngine.Instance.UpdateButtonColor(m_nPlayerIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsBtnEmo : MonoBehaviour
{
    public int m_nBoardIndex;
    public string m_strEmo;

    public GameObject m_goOutline;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitObject()
    {
        UpdateButton();
    }

    public void OnClickEmo()
    {
        CEmoGameEngine.Instance.SetSelectEmo(m_nBoardIndex, m_strEmo);
    }

    public void UpdateButton()
    {
        Debug.Log(CEmoGameEngine.Instance.GetSelectEmo(m_nBoardIndex));
        if (CEmoGameEngine.Instance.GetSelectEmo(m_nBoardIndex).Equals(m_strEmo))
            m_goOutline.SetActive(true);
        else
            m_goOutline.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CUIsEmoPlayBoard : MonoBehaviour
{
    public int m_nPlayerIndex;

    public GameObject[] m_listBtnColor = new GameObject[10];

    public GameObject[] m_listDot = new GameObject[35];

    public GameObject[] m_listEmo = new GameObject[39];

    private string m_strColorKey;

    // Start is called before the first frame update
    void Start()
    {

            //m_listBtnColor[i].GetComponent<Image>().color = CGameData.Instance.GetColor(i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitUIEmoPlayBoard()
    {
        for (int i = 0; i < m_listBtnColor.Length; i++)
        {
            m_listBtnColor[i].GetComponent<CUIsBtnColor>().InitItem(m_nPlayerIndex, i);
        }
    }

    public void UpdateBtn()
    {
        for (int i = 0; i < m_listBtnColor.Length; i++)
            m_listBtnColor[i].GetComponent<CUIsBtnColor>().UpdateItem();
    }

    public void UpdateDotFromEmo(string strKey)
    {
        StopCoroutine("ProcessUpdateDotFromEmo");
        m_strColorKey = strKey;
        StartCoroutine("ProcessUpdateDotFromEmo");
        
    }

    IEnumerator ProcessUpdateDotFromEmo()
    {
        int nColorIndex = 0;
        int nRealColorIndex = 0;
        for (int i = 0; i < m_listDot.Length; i++)
        {
            if (m_strColorKey.Equals("CI00"))
                nColorIndex = 0;
            else if (m_strColorKey.Equals("CI01"))
                nColorIndex = 1;
            else if (m_strColorKey.Equals("CI02"))
                nColorIndex = 2;
            else if (m_strColorKey.Equals("CI03"))
                nColorIndex = 3;
            else if (m_strColorKey.Equals("CI04"))
                nColorIndex = 4;
            else if (m_strColorKey.Equals("CI05"))
                nColorIndex = 5;
            else if (m_strColorKey.Equals("CI06"))
                nColorIndex = 6;
            else if (m_strColorKey.Equals("CI07"))
                nColorIndex = 7;
            else if (m_strColorKey.Equals("CI08"))
                nColorIndex = 8;
            else if (m_strColorKey.Equals("CI09"))
                nColorIndex = 9;
            else
            {
                if (i == 5) nRealColorIndex = 9;
                else if (i == 6) nRealColorIndex = 8;
                else if (i == 7) nRealColorIndex = 7;
                else if (i == 8) nRealColorIndex = 6;
                else if (i == 9) nRealColorIndex = 5;
                else if (i == 15) nRealColorIndex = 19;
                else if (i == 16) nRealColorIndex = 18;
                else if (i == 17) nRealColorIndex = 17;
                else if (i == 18) nRealColorIndex = 16;
                else if (i == 19) nRealColorIndex = 15;
                else if (i == 25) nRealColorIndex = 29;
                else if (i == 26) nRealColorIndex = 28;
                else if (i == 27) nRealColorIndex = 27;
                else if (i == 28) nRealColorIndex = 26;
                else if (i == 29) nRealColorIndex = 25;
                else nRealColorIndex = i;

                nColorIndex = CGameData.Instance.GetEmoColor(m_strColorKey)[nRealColorIndex];
            }

            m_listDot[i].GetComponent<CEmoDot>().UpdateDot(nColorIndex);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnClickAllColor(int nIndex)
    {
        string strKey = "";
        if (nIndex == 0)      strKey = "CI00";
        else if(nIndex == 1)  strKey = "CI01";
        else if (nIndex == 2) strKey = "CI02";
        else if (nIndex == 3) strKey = "CI03";
        else if (nIndex == 4) strKey = "CI04";
        else if (nIndex == 5) strKey = "CI05";
        else if (nIndex == 6) strKey = "CI06";
        else if (nIndex == 7) strKey = "CI07";
        else if (nIndex == 8) strKey = "CI08";
        else if (nIndex == 9) strKey = "CI09";
        UpdateDotFromEmo(strKey);
    }

    public void OnClickSendEmo(int nBoardIndex)
    {
        int nSelectEmoBoard = 0;
        if (nBoardIndex >= 2) nSelectEmoBoard = 1;
        CEmoGameEngine.Instance.UpdateEmoBoard(nBoardIndex, CEmoGameEngine.Instance.GetSelectEmo(nSelectEmoBoard));
    }
}

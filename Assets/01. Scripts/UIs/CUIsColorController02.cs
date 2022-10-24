using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CUIsColorController02 : MonoBehaviour
{
    public int m_nColorIndex;
    public Image m_imgColorBoard;
    public SpriteRenderer[] m_sprColor = new SpriteRenderer[8];
    public SpriteRenderer m_sprSettingColor;
    public Text[] m_listColorValue = new Text[3];

    private Color m_clrBoard;
    private Vector3 m_vecColor;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        m_imgColorBoard.color = CGameData.Instance.GetColor(m_nColorIndex);

        m_clrBoard = m_imgColorBoard.color;
        for(int i = 0; i < m_sprColor.Length; i++)
            m_sprColor[i].color = m_clrBoard;
        m_sprSettingColor.color = m_clrBoard;
        m_vecColor = Clr2Vec(m_clrBoard);

        Debug.Log(m_vecColor);

        m_listColorValue[0].text = ((int)m_vecColor.x).ToString();
        m_listColorValue[1].text = ((int)m_vecColor.y).ToString();
        m_listColorValue[2].text = ((int)m_vecColor.z).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 Clr2Vec(Color clr)
    {
        int r = (int)(clr.r * 255);
        int g = (int)(clr.g * 255);
        int b = (int)(clr.b * 255);

        return new Vector3(r, g, b);
    }

    private Color Vec2Clr(Vector3 vec)
    {
        float r = vec.x / 255;
        float g = vec.y / 255;
        float b = vec.z / 255;

        return new Color(r, g, b);
    }

    public void OnClickUp(int nIndex)
    {
        Debug.Log("Color Index : " + m_nColorIndex + ", RGB Index : " + nIndex);
        int nValue = int.Parse(m_listColorValue[nIndex].text);
        nValue++;
        if (nValue >= 255)
            nValue = 255;

        m_listColorValue[nIndex].text = nValue.ToString();

        int[] listValue = new int[3];
        for (int i = 0; i < m_listColorValue.Length; i++)
        {
            listValue[i] = int.Parse(m_listColorValue[i].text);
        }

        m_vecColor = new Vector3(listValue[0], listValue[1], listValue[2]);
        m_imgColorBoard.color = Vec2Clr(m_vecColor);
        for(int i = 0; i < m_sprColor.Length; i++)
            m_sprColor[i].color = Vec2Clr(m_vecColor);

        m_sprSettingColor.color = Vec2Clr(m_vecColor);

        string strKey = "";

        for (int i = 0; i < 3; i++)
        {
            strKey = "CLR_" + m_nColorIndex.ToString("00") + "_" + i.ToString("00");
            PlayerPrefs.SetInt(strKey, listValue[i]);
            //Debug.Log(strKey + " : " + listValue[i]);
        }

        CGameData.Instance.SetColor(m_nColorIndex, listValue[0], listValue[1], listValue[2]);

        //m_listColor[0] = Vec2Clr(new Vector3((float)PlayerPrefs.GetInt("CLR_00_00", 255),
        //     (float)PlayerPrefs.GetInt("CLR_00_01", 255),
        //     (float)PlayerPrefs.GetInt("CLR_00_02", 255)));

    }

    public void OnClickDown(int nIndex)
    {
        int nValue = int.Parse(m_listColorValue[nIndex].text);
        nValue--;
        if (nValue < 0)
            nValue = 0;

        m_listColorValue[nIndex].text = nValue.ToString();

        int[] listValue = new int[3];
        for (int i = 0; i < m_listColorValue.Length; i++)
        {
            listValue[i] = int.Parse(m_listColorValue[i].text);
        }

        m_vecColor = new Vector3(listValue[0], listValue[1], listValue[2]);
        m_imgColorBoard.color = Vec2Clr(m_vecColor);
        for (int i = 0; i < m_sprColor.Length; i++)
            m_sprColor[i].color = Vec2Clr(m_vecColor);

        m_sprSettingColor.color = Vec2Clr(m_vecColor);

        string strKey = "";
        for (int i = 0; i < 3; i++)
        {
            strKey = "CLR_" + m_nColorIndex.ToString("00") + "_" + i.ToString("00");
            PlayerPrefs.SetInt(strKey, listValue[i]);
        }

        CGameData.Instance.SetColor(m_nColorIndex, listValue[0], listValue[1], listValue[2]); 
    }


}

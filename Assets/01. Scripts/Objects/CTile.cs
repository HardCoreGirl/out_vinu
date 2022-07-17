using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTile : MonoBehaviour
{

    public GameObject[] m_listTile = new GameObject[37];

    public GameObject m_goStart;


    private float[] m_listXpoz = new float[9];
    private float[] m_listYpoz = new float[4];


    private void Awake()
    {
        m_listXpoz[0] = -3.89f;
        m_listXpoz[1] = -2.91f;
        m_listXpoz[2] = -1.95f;
        m_listXpoz[3] = -0.97f;
        m_listXpoz[4] = 0f;
        m_listXpoz[5] = 0.97f;
        m_listXpoz[6] = 1.95f;
        m_listXpoz[7] = 2.91f;
        m_listXpoz[8] = 3.89f;

        m_listYpoz[0] = 1.45f;
        m_listYpoz[1] = 0.49f;
        m_listYpoz[2] = -0.49f;
        m_listYpoz[3] = -1.45f;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitObject(string strText, int nFrame = 0, int nXPoz = 0, int nYPoz = 0, int nStart = 0)
    {
        HideAllTiles();
        ShowTile(strText);

        Debug.Log(m_listXpoz[nXPoz]);

        if (nFrame == 0)
        {
            transform.localPosition = new Vector3(-m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (nFrame == 1)
        {
            transform.localPosition = new Vector3(m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (nFrame == 2)
            transform.localPosition = new Vector3(m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);
        if (nFrame == 3)
            transform.localPosition = new Vector3(-m_listXpoz[nXPoz], m_listYpoz[nYPoz], 0);

        if (nStart == 0)
            m_goStart.SetActive(false);
        else if (nStart == 1)
            m_goStart.SetActive(true);
        else if (nStart == 2)
            m_goStart.SetActive(true);
        else if (nStart == 3)
            m_goStart.SetActive(true);
        else if (nStart == 4)
            m_goStart.SetActive(true);

        StartCoroutine("ProcessShow");
    }

    IEnumerator ProcessShow()
    {
        transform.localScale = new Vector3(0, 0, 1);
        float fScale = 0f;
        while(true)
        {
            fScale += Time.deltaTime;
            transform.localScale = new Vector3(fScale, fScale, 1);

            if (fScale >= 1)
                break;

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = new Vector3(1, 1, 1);
    }

    public void HideAllTiles()
    {
        for(int i = 0; i < m_listTile.Length; i++)
        {
            HideTile(i);
        }
    }

    public void HideTile(int nIndex)
    {
        m_listTile[nIndex].SetActive(false);
    }

    public void ShowTile(string strText)
    {
        switch(strText)
        {
            case "0":
                m_listTile[0].SetActive(true);
                break;
            case "1":
                m_listTile[1].SetActive(true);
                break;
            case "2":
                m_listTile[2].SetActive(true);
                break;
            case "3":
                m_listTile[3].SetActive(true);
                break;
            case "4":
                m_listTile[4].SetActive(true);
                break;
            case "5":
                m_listTile[5].SetActive(true);
                break;
            case "6":
                m_listTile[6].SetActive(true);
                break;
            case "7":
                m_listTile[7].SetActive(true);
                break;
            case "8":
                m_listTile[8].SetActive(true);
                break;
            case "9":
                m_listTile[9].SetActive(true);
                break;
            case "A":
                m_listTile[11].SetActive(true);
                break;
            case "B":
                m_listTile[12].SetActive(true);
                break;
            case "C":
                m_listTile[13].SetActive(true);
                break;
            case "D":
                m_listTile[14].SetActive(true);
                break;
            case "E":
                m_listTile[15].SetActive(true);
                break;
            case "F":
                m_listTile[16].SetActive(true);
                break;
            case "G":
                m_listTile[17].SetActive(true);
                break;
            case "H":
                m_listTile[18].SetActive(true);
                break;
            case "I":
                m_listTile[19].SetActive(true);
                break;
            case "J":
                m_listTile[20].SetActive(true);
                break;
            case "K":
                m_listTile[21].SetActive(true);
                break;
            case "L":
                m_listTile[22].SetActive(true);
                break;
            case "M":
                m_listTile[23].SetActive(true);
                break;
            case "N":
                m_listTile[24].SetActive(true);
                break;
            case "O":
                m_listTile[25].SetActive(true);
                break;
            case "P":
                m_listTile[26].SetActive(true);
                break;
            case "Q":
                m_listTile[27].SetActive(true);
                break;
            case "R":
                m_listTile[28].SetActive(true);
                break;
            case "S":
                m_listTile[29].SetActive(true);
                break;
            case "T":
                m_listTile[30].SetActive(true);
                break;
            case "U":
                m_listTile[31].SetActive(true);
                break;
            case "V":
                m_listTile[32].SetActive(true);
                break;
            case "W":
                m_listTile[33].SetActive(true);
                break;
            case "X":
                m_listTile[34].SetActive(true);
                break;
            case "Y":
                m_listTile[35].SetActive(true);
                break;
            case "Z":
                m_listTile[36].SetActive(true);
                break;
            default:
                m_listTile[10].SetActive(true);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTile : MonoBehaviour
{

    public GameObject[] m_listTile = new GameObject[42];

    public GameObject m_goStart;


    private void Awake()
    {
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

        if (nFrame == 0)
        {
            transform.localPosition = new Vector3(-CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (nFrame == 1)
        {
            transform.localPosition = new Vector3(CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (nFrame == 2)
            transform.localPosition = new Vector3(CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);
        if (nFrame == 3)
            transform.localPosition = new Vector3(-CGameData.Instance.GetGridXPoz(nXPoz), CGameData.Instance.GetGridYPoz(nYPoz), 0);

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
            case "BICYCLE":
                m_listTile[37].SetActive(true);
                break;
            case "HELICOPTER":
                m_listTile[38].SetActive(true);
                break;
            case "CAR":
                m_listTile[39].SetActive(true);
                break;
            case "SHIP":
                m_listTile[40].SetActive(true);
                break;
            case "PLANE":
                m_listTile[41].SetActive(true);
                break;
            default:
                m_listTile[10].SetActive(true);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CUIBoard32Btns : MonoBehaviour
{
    public GameObject m_goColorImage;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        m_goColorImage.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetColor()
    {
        m_goColorImage.SetActive(false);
    }

    public void OnClickColor(int nIndex)
    {
        m_goColorImage.SetActive(true);
        m_goColorImage.GetComponent<Image>().color = CGameData.Instance.GetColor(nIndex);
    }
}

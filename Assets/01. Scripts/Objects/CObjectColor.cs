using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectColor : MonoBehaviour
{
    public SpriteRenderer m_srTarget;
    public int m_nColorIndex;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateColor()
    {
        m_srTarget.color = CGameData.Instance.GetColor(m_nColorIndex);
    }
}

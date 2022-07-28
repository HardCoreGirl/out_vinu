using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CGameData : MonoBehaviour
{
    #region SingleTon
    public static CGameData _instance = null;

    public static CGameData Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CGameData install null");

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            _instance = null;
        }
    }
    #endregion

    private int m_nStage = 0;

    private float[] m_listXpoz = new float[9];
    private float[] m_listYpoz = new float[4];

    private float m_fAnswerSpeed = 1f;

    private bool m_bIsLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitGameData()
    {
        if (!m_bIsLoad)
        {
            m_bIsLoad = true;
            GameObject.DontDestroyOnLoad(this);

            SetStage(0);

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

            m_fAnswerSpeed = 1.5f;
        }
    }

    public void SetStage(int nStage)
    {
        m_nStage = nStage;
    }

    public int GetStage()
    {
        return m_nStage;
    }

    public float GetGridXPoz(int nIndex)
    {
        return m_listXpoz[nIndex];
    }

    public float GetGridYPoz(int nIndex)
    {
        return m_listYpoz[nIndex];
    }

    public float GetAnswerSpeed()
    {
        return m_fAnswerSpeed;
    }    
}

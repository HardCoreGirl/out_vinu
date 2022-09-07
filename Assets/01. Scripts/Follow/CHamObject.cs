using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHamObject : MonoBehaviour
{
    public GameObject m_goGear;
    private float m_fSpeed = 20f;

    private float m_fRotation = 0;
    private int m_nDir = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_fRotation = Random.Range(0, 360f);
        m_nDir = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_nDir == 0)
            m_fRotation += Time.deltaTime * m_fSpeed;
        else
            m_fRotation -= Time.deltaTime * m_fSpeed;

        m_goGear.transform.rotation = Quaternion.Euler(1, 1, m_fRotation);
    }
}

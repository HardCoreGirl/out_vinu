using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGems : MonoBehaviour
{
    private float m_fRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_fRotation += (Time.deltaTime * 30f);

        if (m_fRotation > 360)
            m_fRotation = 0;

        gameObject.transform.rotation = Quaternion.Euler(0, 0, m_fRotation);
    }
}

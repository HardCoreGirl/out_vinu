using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CDotNote : MonoBehaviour
{
    public GameObject m_goTarget;

    private Vector3 m_vecOri;

    private Vector3 m_vecDir;

    private float m_fTotalDelta;

    private bool m_bFinish = true;

    // Start is called before the first frame update
    void Start()
    {
        m_vecOri = transform.localPosition;

        m_vecDir = m_goTarget.transform.localPosition - gameObject.transform.localPosition;

        //Vector3 vecTest = vecDir * -0.3f;
        //Vector3 vecTest = m_vecOri * -vecDir.magnitude;


        //gameObject.transform.localPosition = vecTest;

        //gameObject.transform.DOLocalMove(vecTest, 3f);


        //Sequence seq = DOTween.Sequence()
        //    .Append(gameObject.transform.DOLocalMove(vecTest, 1f).SetSpeedBased())
        //    .Append(gameObject.transform.DOLocalMove(m_vecOri, 1f).SetSpeedBased())
        //    .Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bFinish)
            return;

        //transform.position = Vector3.MoveTowards(transform.position, m_goTarget.transform.position, Time.deltaTime * 1f);
        float fDelta = Time.deltaTime;
        m_fTotalDelta += fDelta;

        if (m_fTotalDelta < 1f)
            transform.Translate(-m_vecDir * fDelta * 0.1f);
        else if (m_fTotalDelta <= 2f)
            transform.Translate(m_vecDir * fDelta * 0.1f);
        else
        {
            m_bFinish = true;
            transform.localPosition = m_vecOri;
        }
    }

    public void PlayDot()
    {
        m_bFinish = false;
    }
}

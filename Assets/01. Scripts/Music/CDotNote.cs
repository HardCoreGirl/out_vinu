using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CDotNote : MonoBehaviour
{
    public GameObject m_goTarget;

    private Vector3 m_vecOri;

    // Start is called before the first frame update
    void Start()
    {
        m_vecOri = transform.localPosition;

        Vector3 vecDir = m_goTarget.transform.localPosition - gameObject.transform.localPosition;

        //Vector3 vecTest = vecDir * -0.3f;
        Vector3 vecTest = m_vecOri * -vecDir.magnitude;


        //gameObject.transform.localPosition = vecTest;

        //gameObject.transform.DOLocalMove(vecTest, 3f);


        Sequence seq = DOTween.Sequence()
            .Append(gameObject.transform.DOLocalMove(vecTest, 1f).SetSpeedBased())
            .Append(gameObject.transform.DOLocalMove(m_vecOri, 1f).SetSpeedBased())
            .Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

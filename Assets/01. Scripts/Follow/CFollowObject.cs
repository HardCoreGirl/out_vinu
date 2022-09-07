using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CFollowObject : MonoBehaviour
{
    public float m_fSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.DOLocalMove(new Vector3(-2, 8, 0), m_fSpeed).SetRelative().SetSpeedBased();
        MoveObject(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObject(bool bIsFirst = false)
    {
        Debug.Log("111111");
        Vector3 vecNowPoz = gameObject.transform.localPosition;
        Vector3 vecTargetPoz = Vector3.zero;

        int nRandomTarget = Random.Range(0, 4);
        int nTarget = 0;
        
        if ( bIsFirst )
        {
            Debug.Log("22222");
            nRandomTarget = Random.Range(0, 4);
            nTarget = nRandomTarget;
        } else
        {
            Debug.Log("Now Poz : " + vecNowPoz.x + ", " + vecNowPoz.y);
            nRandomTarget = Random.Range(0, 3);
            if (vecNowPoz.x <= -17 )
            {
                nTarget = nRandomTarget + 1;
            } else if (vecNowPoz.y == 8 )
            {
                if(nRandomTarget >= 1 )
                    nTarget = nRandomTarget + 1;
                else 
                    nTarget = nRandomTarget; 
            } else if (vecNowPoz.x == -2.5f)
            {
                if (nRandomTarget >= 2)
                    nTarget = nRandomTarget + 1;
                else
                    nTarget = nRandomTarget;
            } else
            {
                nTarget = nRandomTarget;
            }
        }

        float fXPoz = 0;
        float fYPoz = 0;

        if(nTarget == 0 )
        {
            fXPoz = -17f;
            fYPoz = Random.Range(-6, 8);
        } else if( nTarget == 1 )
        {
            fXPoz = Random.Range(-17, -2.5f);
            fYPoz = 8;
        } else if( nTarget == 2 )
        {
            fXPoz = -2.5f;
            fYPoz = Random.Range(-6, 8);
        } else
        {
            fXPoz = Random.Range(-17, -2.5f);
            fYPoz = -6f;
        }

        vecTargetPoz = new Vector3(fXPoz, fYPoz, 0);

        Debug.Log("Target : " + vecTargetPoz.x + ", " + vecTargetPoz.y);

        //gameObject.transform.DOLocalMove(vecTargetPoz, m_fSpeed).SetRelative().SetSpeedBased().OnComplete(() => { MoveObject(); });
        gameObject.transform.DOLocalMove(vecTargetPoz, m_fSpeed).SetSpeedBased().OnComplete(() => { MoveObject(); });
    }
}

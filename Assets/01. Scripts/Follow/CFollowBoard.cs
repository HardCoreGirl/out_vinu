using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CFollowBoard : MonoBehaviour
{
    public GameObject[] m_listMob = new GameObject[2];

    private Vector3[] m_listOriPoz = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        //Sequence seq = DOTween.Sequence()
        //    .Append(m_listMob[0].transform.DOMove(new Vector3(3, 3, 3), 3f))
        //    .Append(m_listMob[0].transform.DOMove(new Vector3(0, 0, 0), 3f))
        //    .Play();
        //m_listMob[0].transform.DOMove(new Vector3(3, 3, 3), 5f);
        for(int i = 0; i < m_listMob.Length; i++)
        {
            m_listOriPoz[i] = m_listMob[i].transform.localPosition;
        }

        MobPlay(0);
        MobPlay(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MobPlay(int nIndex)
    {
        if(nIndex == 0)
        {
            Sequence seq = DOTween.Sequence()
                .Append(m_listMob[0].transform.DOLocalMove(new Vector3(-5.4f, 0.98f, 0), 3f))
                .Append(m_listMob[0].transform.DOLocalMove(new Vector3(-8.29f, 0.98f, 0), 3f))
                .Append(m_listMob[0].transform.DOLocalMove(new Vector3(-5.4f, 0.98f, 0), 3f))
                .Append(m_listMob[0].transform.DOLocalMove(m_listOriPoz[0], 3f))
                .AppendCallback( () => { MobPlay(0); })
                .Play();
        } else
        {
            Sequence seq = DOTween.Sequence()
             .Append(m_listMob[1].transform.DOLocalMove(new Vector3(2.81f, 2.74f), 5f))
             .Append(m_listMob[1].transform.DOLocalMove(m_listOriPoz[1], 5f))
             .AppendCallback(() => { MobPlay(1); })
             .Play();
        }
    }
}

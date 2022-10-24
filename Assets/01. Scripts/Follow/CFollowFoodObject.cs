using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CFollowFoodObject : MonoBehaviour
{

    public int m_nIndex;

    private float m_nItemSpeed = 8f;
    private float m_nMobSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        CGameData.Instance.InitGameData();

        MoveObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveObject()
    {
        if(m_nIndex == 0 )
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(-2.97f, -4.69f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(1.82f, -5.9f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-2.97f, -4.69f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-9f, -3.31f, 0), m_nItemSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        } else if (m_nIndex == 1)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(-1.89f, 0.04f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-2.27f, -2.55f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-1.89f, 0.04f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-0.96f, 3.97f, 0), m_nItemSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        }
        else if (m_nIndex == 2)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(12.11f, -6.95f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(15.69f, -6.83f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(12.11f, -6.95f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(8.2f, -2.55f, 0), m_nItemSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        }
        else if (m_nIndex == 3)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(5.03f, 0.96f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(1.72f, 3.96f, 0), m_nItemSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        }
        else if (m_nIndex == 4)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(-8.86f, 3.34f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-4.14f, 5.13f, 0), m_nItemSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        }
        else if (m_nIndex == 5)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(16.84f, 1.73f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(17.56f, 5.87f, 0), m_nItemSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        }
        else if (m_nIndex == 6)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(5.68f, -7f, 0), m_nItemSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(8.75f, -5.41f, 0), m_nItemSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        }
        else if(m_nIndex == 100)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(-8.66f, 1.53f, 0), m_nMobSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-9.53f, -3.25f, 0), m_nMobSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-2.55f, -4.47f, 0), m_nMobSpeed).SetSpeedBased())
                .Append(gameObject.transform.DOLocalMove(new Vector3(-2.31f, 0.39f, 0), m_nMobSpeed).SetSpeedBased())
                .AppendCallback(() => { MoveObject(); })
                .Play();
        } else if (m_nIndex == 101)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(1.55f, -0.16f, 0), m_nMobSpeed))
                .Append(gameObject.transform.DOLocalMove(new Vector3(2.41f, -2.44f, 0), m_nMobSpeed))
                .Append(gameObject.transform.DOLocalMove(new Vector3(7.62f, -2.44f, 0), m_nMobSpeed))
                .Append(gameObject.transform.DOLocalMove(new Vector3(9.38f, 1.01f, 0), m_nMobSpeed))
                .Append(gameObject.transform.DOLocalMove(new Vector3(7.04f, 1.91f, 0), m_nMobSpeed))
                .AppendCallback(() => { MoveObject(); })
                .Play();
        } else if (m_nIndex == 102)
        {
            Sequence seq = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalMove(new Vector3(16.17f, -1.75f, 0), m_nMobSpeed))
                .Append(gameObject.transform.DOLocalMove(new Vector3(12.27f, -1.3f, 0), m_nMobSpeed))
                .Append(gameObject.transform.DOLocalMove(new Vector3(10.06f, 1.32f, 0), m_nMobSpeed))
                .Append(gameObject.transform.DOLocalMove(new Vector3(13.96f, 3.8f, 0), m_nMobSpeed))
                .AppendCallback(() => { MoveObject(); })
                .Play();
        }
    }
}

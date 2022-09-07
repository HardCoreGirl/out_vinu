using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CReadClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = new Vector3(11, -1, 0);

        MoveObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObject()
    {
        Sequence seq = DOTween.Sequence()
        .Append(gameObject.transform.DOLocalMove(new Vector3(7f, 1f, 0), 6f))
        .Append(gameObject.transform.DOLocalMove(new Vector3(11f, 7f, 0), 8f))
        .Append(gameObject.transform.DOLocalMove(new Vector3(16f, 1, 0), 6f))
        .Append(gameObject.transform.DOLocalMove(new Vector3(11f, -1f, 0), 8f))
        .AppendCallback(() => { MoveObject(); })
        .Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEmoDot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDot(int nColorIndex)
    {
        StopCoroutine("ProcessUpdateDot");
        gameObject.GetComponent<SpriteRenderer>().color = CGameData.Instance.GetColor(nColorIndex);
        StartCoroutine("ProcessUpdateDot");
    }

    IEnumerator ProcessUpdateDot()
    {
        float fScale = 1.3f;
        float fSpeed = 0.7f;

        gameObject.transform.localScale = new Vector3(fScale, fScale, fScale);

        while (true)
        {
            fScale -= (Time.deltaTime * fSpeed);

            if (fScale <= 1)
                break;

            gameObject.transform.localScale = new Vector3(fScale, fScale, fScale);

            yield return new WaitForEndOfFrame();
        }

        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}

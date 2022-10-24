using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsAniAnswerManager : MonoBehaviour
{
    public GameObject[] m_listAnswer = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnswer(int nIndex)
    {
        //m_listAnswer[nIndex].GetComponent<Animator>().playbackTime = 0;
        //m_listAnswer[nIndex].GetComponent<Animator>().StopPlayback();
        //m_listAnswer[nIndex].GetComponent<Animator>().StartPlayback();
        m_listAnswer[nIndex].GetComponent<Animator>().Rebind();
        m_listAnswer[nIndex].GetComponent<Animator>().Play("Answer");
    }
}

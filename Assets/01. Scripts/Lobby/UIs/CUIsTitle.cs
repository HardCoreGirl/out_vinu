using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        CLobbyManager.Instance.ShowUIs(1);
    }
}

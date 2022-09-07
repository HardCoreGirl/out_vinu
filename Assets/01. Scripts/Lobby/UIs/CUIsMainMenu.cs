using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIsMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMode(int nIndex)
    {
        int nUIIndex = nIndex + 2;

        CLobbyManager.Instance.ShowUIs(nUIIndex);
    }
}

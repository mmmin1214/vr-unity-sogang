using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        
    }

    void Awake()
    {
        Debug.Log("awake");
        int i = 5;
        if(i >= 0)
        {

        }
    }
}

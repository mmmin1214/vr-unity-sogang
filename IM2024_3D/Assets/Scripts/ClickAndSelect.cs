using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndSelect : MonoBehaviour
{
    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}

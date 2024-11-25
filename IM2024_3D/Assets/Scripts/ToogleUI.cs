using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleUI : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ToggleSelf()
    {
        bool isActive =  this.gameObject.activeSelf;  // true or false
        this.gameObject.SetActive(!isActive);   // if isActive is 'true' > !isActive = 'false'
    }
    
}

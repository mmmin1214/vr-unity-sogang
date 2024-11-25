using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI2 : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void PopupInfo()
    {
        bool isActive = this.gameObject.activeSelf; // return 'true' or 'false' 
        this.gameObject.SetActive(!isActive);
    }

}

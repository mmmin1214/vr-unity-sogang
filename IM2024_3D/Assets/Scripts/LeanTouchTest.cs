using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTouchTest : MonoBehaviour
{
    public void PressToDelete()
    {
        Debug.Log(this.gameObject.name + "is destroyed!");
        Destroy(this.gameObject);
    }
}

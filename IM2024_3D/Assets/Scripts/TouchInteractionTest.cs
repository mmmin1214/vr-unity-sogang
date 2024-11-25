using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInteractionTest : MonoBehaviour
{
    public void PressToDestroy()
    {
        Destroy(this.gameObject);
        Debug.Log("pressed!and destroy!" + this.gameObject.name);
    }

}

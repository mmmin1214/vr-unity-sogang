using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRDebugText : MonoBehaviour
{
    public TextMeshPro UITextMeshPro;

    public void DebugText(string t)
    {
        Debug.Log(this+t);
        UITextMeshPro.text = t;

    }
}

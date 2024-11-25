using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.name.Contains("waypoint"))
        {
            Debug.Log("OnCollisionEnter");
            c.gameObject.SetActive(false);
        }
    }
}

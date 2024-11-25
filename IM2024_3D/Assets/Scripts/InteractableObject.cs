using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public int maxStep; 
    public int currentStep;

    void Start()
    {
        maxStep = this.transform.childCount;
        currentStep = 0;
        UpdateInfoPanel();
    }

    public void UpdateInfoPanel()
    {
        if(currentStep == maxStep)
        {
            currentStep = 0;
        }

        for(int i= 0; i<maxStep; i++)
        {
            if(i == currentStep)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        currentStep++;
    }

}

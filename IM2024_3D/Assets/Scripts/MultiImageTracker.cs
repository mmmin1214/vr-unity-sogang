using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultiImageTracker : MonoBehaviour
{
    public ARTrackedImageManager arImageManager;
    public GameObject[] placeablePrefabs;
    Dictionary<string, GameObject> spawnedObjects;

    void Start()
    {
        spawnedObjects = new Dictionary<string, GameObject>();

        foreach(GameObject obj in placeablePrefabs)
        {
            GameObject newObj = Instantiate(obj);
            newObj.name = obj.name;
            newObj.SetActive(false);

            spawnedObjects.Add(newObj.name, newObj);
        }   
    }

    void OnEnable()
    {
        arImageManager.trackedImagesChanged +=  OnTrackedImageChanged;
    }
    void OnDisable()
    {
        arImageManager.trackedImagesChanged -=  OnTrackedImageChanged;
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.name].SetActive(false);
        }
    }

    void UpdateSpawnObject(ARTrackedImage trackedImage)
    {
        string referenceImageName = trackedImage.referenceImage.name;
        spawnedObjects[referenceImageName].transform.position = trackedImage.transform.position;
        spawnedObjects[referenceImageName].transform.rotation = trackedImage.transform.rotation;
        spawnedObjects[referenceImageName].SetActive(true);
    }

 
}

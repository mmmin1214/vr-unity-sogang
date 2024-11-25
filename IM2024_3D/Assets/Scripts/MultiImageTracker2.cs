using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultiImageTracker2 : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject[] prefabs;

    Dictionary<string, GameObject> spawnedObjects;

    public GameObject objectHolder;

    void Start()
    {
        ResetARObjects();
    }

    public void ResetARObjects()
    {
        spawnedObjects = new Dictionary<string, GameObject>();

        foreach(GameObject obj in prefabs)
        {
            GameObject newObject = Instantiate(obj, objectHolder.transform);
            newObject.name = obj.name;
            newObject.SetActive(false);

            spawnedObjects.Add(newObject.name, newObject);
        }       
    }

    public void DestroyARObjects()
    {
        foreach(Transform child in objectHolder.transform)
        {
            Destroy(child.gameObject);
        }

        spawnedObjects.Clear();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedIamgeChange;
    }

    void OnDisable()
    {          
        trackedImageManager.trackedImagesChanged -= OnTrackedIamgeChange;
    }

    void OnTrackedIamgeChange(ARTrackedImagesChangedEventArgs eventArgs)
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
        spawnedObjects[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
        spawnedObjects[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;
        spawnedObjects[trackedImage.referenceImage.name].SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultiImageTrack1025 : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject[] prefabs;

    Dictionary<string, GameObject> spawnedObjects;

    public GameObject objectHolder;


    void Start()
    {
        ResetOject();
    }

    public void ResetOject()
    {
        spawnedObjects = new Dictionary<string, GameObject> ();

        foreach(GameObject obj in prefabs)
        {
            GameObject newObj = Instantiate(obj, objectHolder.transform);
            newObj.name = obj.name;
            newObj.SetActive(false);

            spawnedObjects.Add(newObj.name, newObj);
        }
    }

    public void DestroySpawnedObject()
    {
        foreach(Transform child in objectHolder.transform)
        {
            Destroy(child.gameObject);
        }
        spawnedObjects.Clear();

        ResetOject();
    }



    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }
    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }



    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateSpawnedObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateSpawnedObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.referenceImage.name].SetActive(false);
        }
    }

    void UpdateSpawnedObject(ARTrackedImage trackedImage)
    {
        spawnedObjects[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
        spawnedObjects[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;

        spawnedObjects[trackedImage.referenceImage.name].SetActive(true);
    }

}

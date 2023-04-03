using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;

    public static ArrowPool instance;

    List<GameObject> pooledObjects = new List<GameObject>();
    int amountToPool = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i< amountToPool; i++) 
        {
            GameObject obj = Instantiate(arrowPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i< pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

    public GameObject GetMultipleObjects(int j)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i + j].activeInHierarchy)
            {
                return pooledObjects[i + j];
            }
        }

        return null;
    }
}

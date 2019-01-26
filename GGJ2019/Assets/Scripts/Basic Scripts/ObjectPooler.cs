using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    // Setting variables
    public GameObject pooledObject;
    // Container to put your pool your objects in. If empty, it will create its own.
    public GameObject containerObject;
    public int pooledAmount;
    //Determines whether or not you want the game objects to spawn as active game objects
    public bool startActive = false;

    private GameObject poolContainer;
    List<GameObject> pooledObjects = new List<GameObject>();

    // Use this for initialization
    protected void Start()
    {
        if(!containerObject)
        {
            poolContainer = new GameObject();
            poolContainer.name = pooledObject.name + " Container";
            containerObject = poolContainer;
        }
        else
        {
            poolContainer = containerObject;
        }
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject, poolContainer.transform);
            obj.SetActive(startActive);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects != null)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.transform.parent = poolContainer.transform;
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
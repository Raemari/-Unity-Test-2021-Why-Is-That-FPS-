using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class ObjectPoolItems
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
}

public class ObjectPool : MonoBehaviour
{
    //singleton to be easily accesible to other classes
    public static ObjectPool instance;
    private List<GameObject> pooledObjects;
    public List<ObjectPoolItems> itemsToPool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //to instantiate the number of gameObjects(in this case, enemyprefab)
        //based on the specified number of amountToPool
        pooledObjects = new List<GameObject>();
        foreach(ObjectPoolItems item in itemsToPool)
        {
            //TODO check if i can disbale the navmesh in this part???
            for(int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
    //used GameObject instead of void because this returns the gameObject to be pooled(enemyPrefab)
    public GameObject GetPooledObject(string tag)
    {
        //to iterate through the pooledObjectList if the pooled object is active in hierarchy
        //if theres no inactive pooled object(enemyprefab) exit function
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach(ObjectPoolItems item in itemsToPool)
        {
            if(item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}

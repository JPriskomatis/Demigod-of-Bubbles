using System.Collections.Generic;
using UnityEngine;

public class ScissorPool : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;

    public static ScissorPool instance { get; private set; }

    public GameObject objectToPool;

    public int poolSize;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        pooledObjects = new Queue<GameObject>();

        //This tmp value will be the prefab to populate our Queue
        GameObject tmp;

        for (int i = 0; i < poolSize; i++)
        {
            //We populate the Queue with our prefab;
            tmp = Instantiate(objectToPool);

            //Important to set it as inactive;
            tmp.SetActive(false);

            //Enqueue adds an element to the Queue;
            pooledObjects.Enqueue(tmp);

        }
    }

    public GameObject GetPooledObject()
    {
        if (pooledObjects.Count > 0)
        {
            //Removes an item from the Queue;
            GameObject obj = pooledObjects.Dequeue();

            if (obj != null)
            {

                //This is the gameobject that we activate in our scene;
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public void ReturnPooledObject(GameObject obj)
    {
        obj.SetActive(false);

        //Endqueue adds the item to the end of our queue;
        pooledObjects.Enqueue(obj);
    }
}

using System;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [System.Serializable]
    public class Pool
    {
        public string type;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools = new List<Pool>();

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    private void Awake()
    {
        Instance = this;

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.type, objectPool);
        }
    }

    private void Start()
    {
        
    }

    public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(type))
        {
            Debug.LogWarning($"Pool type : {type} does not exist");
            return null;
        }

        GameObject obj = poolDictionary[type].Dequeue(); //fetches an inactive object from the pool
        obj.SetActive(true);
        obj.transform.SetPositionAndRotation(position, rotation);

        poolDictionary[type].Enqueue(obj); //re adds to the pool for reusing
        return obj;
    }
}

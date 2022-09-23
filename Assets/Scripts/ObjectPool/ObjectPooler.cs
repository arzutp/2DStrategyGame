using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in Pools) //poola istenen sayýda obje ekliyoruz
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab,transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parentTransform)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Doesn't excist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.transform.parent = parentTransform;
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObject != null)
            pooledObject.OnObjectSpawn();
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}

[System.Serializable]
public class Pool
{
    public string Tag;
    public GameObject Prefab;
    public int Size;
}
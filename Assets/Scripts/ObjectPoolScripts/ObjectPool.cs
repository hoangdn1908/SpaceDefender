using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private int poolSize;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private HashSet<GameObject> poolObjects = new HashSet<GameObject>();

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool() 
    {
        for (int i = 0; i < poolSize; i++) 
        {
            CreateObjects();
        }
    }

    private void CreateObjects() 
    {
        GameObject gameObject = Instantiate(prefabs, transform);
        gameObject.SetActive(false);
        pool.Enqueue(gameObject);
        poolObjects.Add(gameObject);
    }

    public GameObject GetFromPool() 
    {
        if (pool.Count == 0) CreateObjects();
        GameObject gameObject = pool.Dequeue();
        poolObjects.Remove(gameObject);
        gameObject.transform.SetParent(null, true);
        gameObject.SetActive(true);
        return gameObject;
    }

    public void ReturnToPool(GameObject gameObject) 
    {
        if (gameObject == null) return;
        if (poolObjects.Contains(gameObject)) return;
        gameObject.transform.SetParent(transform, true);
        gameObject.SetActive(false);
        pool.Enqueue(gameObject);
        poolObjects.Add(gameObject);
    }
}

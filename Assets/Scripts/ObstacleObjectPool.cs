using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] public T prefab;

    public static ObstacleObjectPool<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
    {
        if(objects.Count == 0)
        {
            AddObjects(1);
        }
        return objects.Dequeue();
    }
    private void AddObjects(int count)
    {
        var newObject = GameObject.Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objects.Enqueue(newObject);

    }
    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}
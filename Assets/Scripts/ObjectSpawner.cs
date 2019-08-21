using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns whatever prefabs are in its array randomly at random times.
/// 
/// TODO: I need to create something to control screenbounds for obstacles to delete and spawn.
/// 
/// </summary>

public class ObjectSpawner : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;
    public float respawnTime;
    public float respawnTimeMin;
    public float respawnTimeMax;
    public int prefabNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstacleWave());
    }

    private void SpawnObstacle(int arrayNumber)
    {
        ObjectPooler.Instance.SpawnFromPool(obstaclePrefabs[arrayNumber].tag, new Vector3(transform.position.x, (transform.position.y + obstaclePrefabs[arrayNumber].transform.position.y),transform.position.z), transform.rotation);
        //Instantiate(obstaclePrefabs[arrayNumber], transform.position, Quaternion.identity);
    }

    IEnumerator ObstacleWave()
    {
        //Change 'true' to gamestarted controled by a gameManager
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnObstacle(prefabNumber);
            NewRespawnTime();
            NewPrefabNumber();
        }
    }
    private void NewRespawnTime()
    {
        respawnTime = Random.Range(respawnTimeMin, respawnTimeMax);
    }
    private void NewPrefabNumber()
    {
        prefabNumber = Random.Range(0, obstaclePrefabs.Length);
    }
}

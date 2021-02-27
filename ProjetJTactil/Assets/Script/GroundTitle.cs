using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTitle : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject prefab1, prefab2, prefab3, prefab4;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        // choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(3, 6);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        // Spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}

using UnityEngine;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    public List<Transform> spawners;
    public GameObject skeletonPrefab;
    public float spawnInterval = 5f; 
    private float lastSpawnTime;
    private bool isSpawning = false;

    public void StartSpawning()
    {
        isSpawning = true;
        lastSpawnTime = Time.time;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        if (!isSpawning) return;

        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            foreach (Transform spawner in spawners)
            {
                SpawnSkeleton(spawner.position);
            }
            lastSpawnTime = Time.time;
        }
    }

    // Fonction pour faire apparaître un squelette à une position donnée
    void SpawnSkeleton(Vector3 position)
    {
        Instantiate(skeletonPrefab, position, Quaternion.identity);
    }
}
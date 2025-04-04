using UnityEngine;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    public List<Transform> spawners; // Liste des emplacements des spawners
    public GameObject skeletonPrefab; // Préfabriqué du squelette à faire apparaître
    public float spawnInterval = 5f; // Intervalle de temps entre les apparitions

    private float lastSpawnTime;

    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update()
    {
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
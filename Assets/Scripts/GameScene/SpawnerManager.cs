using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnerManager : MonoBehaviour
{
    public List<Transform> spawners; // Liste des emplacements des spawners
    public GameObject skeletonPrefab; // Préfabriqué du squelette à faire apparaître
    public int baseSkeletonCount = 4; // Ennemis dans la vague 1
    public float spawnCooldown = 1f; // Temps entre chaque spawn de squelette

    private List<GameObject> spawnedSkeletons = new List<GameObject>(); 

    public void SpawnWave(int waveNumber)
    {
        foreach (var skeleton in spawnedSkeletons)
        {
            if (skeleton != null && skeleton.activeInHierarchy == false)
            {
                Destroy(skeleton); 
            }
        }

        spawnedSkeletons.Clear();

        int skeletonsToSpawn = baseSkeletonCount + (waveNumber - 1) * 2;

        int spawnedAtSpawners = 0;
        for (int i = 0; i < spawners.Count; i++)
        {
            GameObject newSkeleton = Instantiate(skeletonPrefab, spawners[i].position, Quaternion.identity);
            spawnedSkeletons.Add(newSkeleton); 
            spawnedAtSpawners++;
            skeletonsToSpawn--;
        }

        StartCoroutine(SpawnRemainingSkeletons(skeletonsToSpawn));
    }

    private IEnumerator SpawnRemainingSkeletons(int remainingSkeletons)
    {
        for (int i = 0; i < remainingSkeletons; i++)
        {
            Transform chosenSpawner = spawners[Random.Range(0, spawners.Count)];
            GameObject newSkeleton = Instantiate(skeletonPrefab, chosenSpawner.position, Quaternion.identity);
            spawnedSkeletons.Add(newSkeleton);

            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
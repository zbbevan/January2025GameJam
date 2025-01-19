using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] prefabSpawns;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();

    private int maxSpawns = 1;
    private float spawnTime = 5f;
    public float lastSpawn = 0f;

    private Vector3? lastDestroyedPosition = null;

    [SerializeField] private AudioClip spawnSound;

    void Update()
    {
        for (int i = spawnedPrefabs.Count - 1; i >= 0; i--)
        {
            if (spawnedPrefabs[i] == null)
            {
                if (lastDestroyedPosition == null)
                {
                    if (spawnedPrefabs[i] != null)
                    {
                        lastDestroyedPosition = spawnedPrefabs[i].transform.position;
                    }
                }

                lastSpawn = Time.time; 

                spawnedPrefabs.RemoveAt(i);
            }
        }

        if (Time.time > lastSpawn + spawnTime && spawnedPrefabs.Count < maxSpawns)
        {
            Vector3 spawnPosition = lastDestroyedPosition ?? spawnPoint.position;

            GameObject prefabToSpawn = prefabSpawns[Random.Range(0, prefabSpawns.Length)];

            GameObject newObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            spawnedPrefabs.Add(newObject);

            lastDestroyedPosition = null; 
        }
    }
}
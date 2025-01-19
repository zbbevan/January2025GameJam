using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] prefabSpawns;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();

    private Inventory invent;

    private int maxSpawns = 1;
    private float spawnTime = 5f;
    private float lastSpawn = 0f;

    [SerializeField] private AudioClip spawnSound;
        void Update()
    {
        if (Time.time > lastSpawn + spawnTime)
        {
            GameObject prefabToSpawn = prefabSpawns[Random.Range(0, prefabSpawns.Length)];

            GameObject newObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

            lastSpawn = Time.time;
        }
    }
        void OnDestroy()
    {
        lastSpawn = Time.time;
    }

}

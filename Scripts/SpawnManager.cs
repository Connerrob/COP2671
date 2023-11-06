using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // An array of game objects to spawn
    public GameObject[] gamePrefabs;

    // Reference to the GameUI script
    private GameUI gameUI;

    private float spawnRangeX = 25; // Range for spawning along the X-axis
    private float spawnPosZ = 40; // Position along the Z-axis where objects are spawned
    private float startDelay = 2; // Delay before spawning starts
    private float spawnInterval = 3f; // Time between spawns
    void Start()
    {
        // Find and store a reference to the GameUI script
        gameUI = FindObjectOfType<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void StartSpawn ()
    {
        // Start the coroutine for spawning objects
        StartCoroutine(SpawnAnimalRoutine());
    }
    IEnumerator SpawnAnimalRoutine()
    {
        // Wait for the start delay before spawning begins
        yield return new WaitForSeconds(startDelay);

        // Keep spawning objects as long as the game is active
        while (gameUI.gameActive)
        {
            // Spawn a random animal/object
            SpawnRandomAnimal();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void SpawnRandomAnimal()
    {
        // Spawn a random animal/object
        int prefabIndex = Random.Range(0, gamePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(gamePrefabs[prefabIndex], spawnPos, gamePrefabs[prefabIndex].transform.rotation);
    }
}

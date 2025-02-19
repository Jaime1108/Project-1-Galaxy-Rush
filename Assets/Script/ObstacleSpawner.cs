using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  // Array of different obstacle prefabs
    public float spawnInterval = 2f;       // Time interval between each spawn
    public float spawnHeight = 20f;         // Y position range for spawning
    public float spawnDepth = 400f;         // Z position range for spawning
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        // Random Y (height) and Z (depth) for variety
        float randomY = Random.Range(28, spawnHeight);
        float randomZ = Random.Range(400, 600);

        // Randomly pick an obstacle prefab
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);  
        GameObject selectedObstacle = obstaclePrefabs[randomIndex];

        // Spawn at a position in front of the player
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, randomZ);
        Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);
    }
}

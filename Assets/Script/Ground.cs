using UnityEngine;

public class Ground : MonoBehaviour
{
    private GroundSpawner groundSpawner; // GroundSpawner  object to create a new ground

    public GameObject[] obstaclePrefab; // Array to store different obstacle prefabs
    void Start()
    {
        groundSpawner = GameObject.FindFirstObjectByType<GroundSpawner>();  // get the GroundSpawner in the scene
        // Pick a random obstacle and a spawn position for it
        int obstacle1 = Random.Range(0,3);
        int obstaclePosition1 = Random.Range(3,6); // Choosing a random child index (spawn point)
        SpawnObstacle(obstacle1, obstaclePosition1);
        int obstacle2 = Random.Range(0,3);
        int obstaclePosition2 = Random.Range(3,6);
        // Keep picking a different position if it's the same as the first
        while (obstaclePosition2 == obstaclePosition1){
            obstaclePosition2 = Random.Range(3,6); // Choosing a random child index (spawn point)
        }
        SpawnObstacle(obstacle2, obstaclePosition2);
    }
    private void OnTriggerExit (Collider other){

        groundSpawner.SpawnTile(); // Spawn a new ground tile
        Destroy(gameObject,2); // Delete this tile after the player walk pass through it
    }
    //spawning a type obstacle at a given position
     public void SpawnObstacle( int obstacleType, int ObstacleSpawnIndex){
        Transform spawnPoint = transform.GetChild(ObstacleSpawnIndex).transform; // Get the specific spawn point
        Instantiate(obstaclePrefab[obstacleType], spawnPoint.position, Quaternion.identity, transform);  // Spawn obstacle
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

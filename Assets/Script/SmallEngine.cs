using UnityEngine;
//This is a file for the small engines of my ship which aim to shoot smoke periodically
public class SmallEngine : MonoBehaviour
{
    public GameObject smokePrefab;  // Reference to the smoke sphere prefab
    public float frequence = 0.06f;    // Spawns smoke every 1 second

    private float timeSinceLastEmission = 0f; // Timer to control emission intervals

    void Update()
    {
        timeSinceLastEmission += Time.deltaTime;

        if (timeSinceLastEmission >= frequence) // Corrected variable name
        {
            ShootSmoke();
            timeSinceLastEmission = 0f; // Reset the timer
        }
    }

    void ShootSmoke()
    {
        // Instantiate the smoke prefab at the small engines position
        GameObject smokeInstance = Instantiate(smokePrefab, transform.position, Quaternion.identity);
    }
}

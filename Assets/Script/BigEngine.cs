using UnityEngine;


//This is a file for my Big engine of my ship which aim to shoot smoke periodically
public class BigEngine : MonoBehaviour
{
    public GameObject smokePrefab;  // Reference to the smoke sphere prefab
    private float frequence = 0.04f;    // frequence of smoke spawning

    private float timeAfterLastSmoke = 0f; // Timer to control emission intervals

    void Update()
    {
        timeAfterLastSmoke += Time.deltaTime;

        if (timeAfterLastSmoke >= frequence) // Corrected variable name
        {
            ShootSmoke();
            timeAfterLastSmoke = 0f; // Reset the timer
        }
    }

    void ShootSmoke()
    {
        // Instantiate the smoke prefab at the BigEngine position
        GameObject smokeInstance = Instantiate(smokePrefab, transform.position, Quaternion.identity);


    }
}

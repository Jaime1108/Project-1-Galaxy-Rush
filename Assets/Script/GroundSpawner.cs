using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ground; //the prefab that will be use to spawn ground 

    Vector3 SpawnPoint;  // the spawn point for the next ground 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SpawnTile() { 
        // Instantiate the ground prefab at the current spawn point without rotation
        GameObject temporGround = Instantiate(ground, SpawnPoint, Quaternion.identity);
        // Set the spawn point for the next tile based on the position of a child object inside the prefab
        SpawnPoint = temporGround.transform.GetChild(1).transform.position;
        
    }
   
    void Start()
    {   
        //  spawn 10 tiles initially
        for(int i = 0; i < 10; i++){
            SpawnTile();
        }
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

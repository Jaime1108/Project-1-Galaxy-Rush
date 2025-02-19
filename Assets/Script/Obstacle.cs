using UnityEngine;

public class Obstacle : MonoBehaviour
{
    ShipMovement shipMovement;  // create an object of ShipMovement script to call Die
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get a reference to the ShipMovement script
        shipMovement = GameObject.FindFirstObjectByType<ShipMovement>();
    }
    
     // This function is used to detect if an object of obstacle collides with another object
    private void OnTriggerEnter(Collider collision){
       
        /// Check if the object collided with the player (X-wing)
        if(collision.gameObject.name == "X-wing"){
            shipMovement.Die();
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
// This script makes the camera follow the spaceship
public class CameraFollower : MonoBehaviour
{
    public Transform spaceship;
    
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //get the initial offset between the camera and the spaceship
        offset = transform.position - spaceship.position;
    }

    // Update is called once per frame
    private void Update()
    {
         // Calculate the target position for the camera while maintaining the offset
        Vector3 targetPosition = spaceship.position + offset;
        targetPosition.x = 0; // Keep the camera centered on the X-axis
    
        transform.position = targetPosition; // Apply the new position to the camera
    }
}

using UnityEngine;
//This is a script that assist with the spinning mechanic of the spaceship
public class Spinning : MonoBehaviour
{
    public float rotationSpeed = 150f;
    public float spinningAcceleration = 0.0001f;
    private float idleTime = 0f;        // Timer to track idle time (no key pressed)
    public float resetTime = 2f;        // Time after which the ship starts returning to neutral rotation
    public float resetSpeed = 1f;       // Speed at which the ship returns to its original rotation
    private Quaternion initialRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame 
    // /*
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Z)){
        // Rotate left (clockwise on the Z-axis)
        transform.rotation *= Quaternion.Euler(-rotationSpeed * Time.deltaTime, 0, 0);
        idleTime = 0f;  // Reset idle time when a key is pressed
        }
    // Check if the player is pressing the D key
        else if (Input.GetKey(KeyCode.X))
        {
            // Rotate right (counter-clockwise on the Z-axis)
            transform.rotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime, 0, 0);
            idleTime = 0f;  // Reset idle time when a key is pressed
        }
        else{
            idleTime += Time.deltaTime;
            if (idleTime >= resetTime){
                // Slowly rotate back to the original rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, resetSpeed * Time.deltaTime);
            }
        }

    }
    void Update(){

        rotationSpeed += spinningAcceleration * Time.deltaTime;

    }

    
}
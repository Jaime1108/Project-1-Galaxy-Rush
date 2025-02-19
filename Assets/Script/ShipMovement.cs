using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    
    public float speed = 60f; //Initial speed of the ship
    public float acceleration = 0.0000f; // Initial Acceleration value
    public Rigidbody rb; //Rigidbody  object
    float horizontalInput; //player horizontal input
    public float horizontalMultiplier = 7; // Speed multiplier for horizontal movement
    private bool isAccel; // Tracks if the player is accelerating
    private bool isAlive = true;
    public float rotationSpeed = 100f; // Reduced rotation speed for better control
    public float maxTiltAngle = 25f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate(){
        //if the user is dead
        if(!isAlive){
            return;
        }
        // Calculate movement directions
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime; //This continously moves the ship in the forward direction with speed.
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.deltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove); // Apply movement to the Rigidbody
        float currentTilt = transform.localEulerAngles.z;
        if (currentTilt > 180f) currentTilt -= 360f; // Convert to range -180 to 180

        // Handle rotation within limits
        if (Input.GetKey(KeyCode.A) && currentTilt < maxTiltAngle)
        {
            Quaternion deltaRotation = Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        else if (Input.GetKey(KeyCode.D) && currentTilt > -maxTiltAngle)
        {
            Quaternion deltaRotation = Quaternion.Euler(0, 0, -rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetKey(KeyCode.W) ){ //acceleration when pressing "W"
            if(acceleration <= 10){
                acceleration += 0.1f;
            }
            isAccel = true;
            
        }
        else if (Input.GetKey(KeyCode.S) ){ //decceleration when pressing "W"
            if(acceleration >=- 10){ 
            acceleration -= 0.1f;
            }
            isAccel = false;
            
        } else {
            //slowly reset acceleration if idle
            if(acceleration > 0){
                acceleration -= 0.1f;
            }
            else if(acceleration < 0){
                acceleration += 0.1f;
            }
        }
        
    }
    // Restricts the ship's position to stay within the trench walls
    private void RestrictPosition(){
        float minX = -20.5f; //left wall boundary
        float maxX =  20f; //righ wall boundary
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        transform.position = currentPosition;
    }
    
    // Update is called once per frame
    private void Update()
    {
        // Adjust speed based on acceleration 
        if(speed <= 200 && isAccel == true && acceleration >=0){
            speed += acceleration * Time.deltaTime;} 
        else if (speed >= 60 && acceleration <=0 && isAccel == false){
            speed += acceleration * Time.deltaTime;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        RestrictPosition();
    }
    // Handles player death
        public void Die(){
        isAlive = false;
        // Reload the game scene when the player dies
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;

//This is the script that change the smoke behaviour (shrinking it after shooting out of engine and destroy it)
public class SmokeBehavior : MonoBehaviour
{
    public float disappearTime = 2f;  // Time before the smoke disappears
    public float smokeSpeed = 5f;     // Speed at which the smoke moves
    public Vector3 smokeDirection = Vector3.back; // Moves smoke in the backward direction
    
    private float timer = 0f;         // Timer to track lifetime
    private Vector3 initialScale;     // Stores the original size
    private float scaleFactor; // scale factor = 100% 

    void Start()
    {
        initialScale = transform.localScale; // Save the initial scale of the smoke object
        
    }

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Calculate scale factor based on the elapsed time
        scaleFactor = 1f - timer / disappearTime; // Scale reduces over time

        // Apply the scale to the smoke
        transform.localScale = initialScale * scaleFactor;
        // Destroy the smoke
        Destroy(gameObject, disappearTime);
        
    }
}

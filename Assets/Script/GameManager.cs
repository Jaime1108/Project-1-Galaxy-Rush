using UnityEngine;
using UnityEngine.UI; // For displaying the score on UI
using TMPro;    
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance to access the GameManager globally

    public float score = 0f; // Distance-based score
    public GameObject spaceship; // Reference to the spaceship GameObject

    private ShipMovement shipMovement; // Reference to the PlayerMovement script
    public TMP_Text scoreText; // UI text to display score
    public TMP_Text highScoreText; // UI text to display highscore
    private float highScore = 0f;
    private void Start()
    {        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Default to 0 if no high score is saved

        // Update the high score text
        highScoreText.text = "High Score: " + highScore.ToString();
        // Find the player (ship) and set its starting position
        shipMovement = spaceship.GetComponent<ShipMovement>();
        
    }

    private void Update()
    {
        score += (shipMovement.speed * Time.deltaTime)/20;
        int formattedScore = (int)Math.Round(score);
        scoreText.text = "Score: " + formattedScore.ToString();
        // Update the high score if the current score is higher
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);  // Save the new high score to PlayerPrefs
        }

        // Display the high score
        int formattedHighScore = (int)Math.Round(highScore);
        highScoreText.text = "High Score: " + formattedHighScore.ToString();
}
}

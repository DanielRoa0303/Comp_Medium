using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Import the TextMeshPro namespace
using TMPro; 

public class TimerScript : MonoBehaviour
{
    // Time limit in sec format
    public float timeLimit = 90f;

    // Use TextMeshPro for the Timer ext
    public TextMeshProUGUI Timer; 

    // Reference to GameEnding script
    public GameEnding gameEnding;

    private float timeRemaining;

    void Start()
    {
        // Initialize the remaining time
        timeRemaining = timeLimit;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            // Reduce the remaining time
            timeRemaining -= Time.deltaTime;

            // Update the timer text on the screen
            UpdateTimerUI();
        }
        else
        {
            // So that when timer hits 0, it stop, so it doesnt continue with negative nums.
            timeRemaining = 0;

            // Game ends when Timer hits 0. The caught image is displayed
            gameEnding.CaughtPlayer();
        }
    }
    public void StopTimer()
    {
        // Stop Timer
        timeRemaining = 0; 
    }

    void UpdateTimerUI()
    {
        // transform remaining time to minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Display time in "MM:SS" format in TiimerText
        Timer.text = $"Time: {minutes:00}:{seconds:00}";
    }
}

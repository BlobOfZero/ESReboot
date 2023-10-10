using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacks : MonoBehaviour
{

    public float countdownDuration = 5f;
    public float pauseDuration = 2f;

    private float currentTime;
    private bool isCountingDown = true;
    [SerializeField] private GameObject knifeRange;

    private void Start()
    {
        // Start the countdown
        currentTime = countdownDuration;
    }

    private void Update()
    {
        if (isCountingDown)
        {
            // Update the countdown timer
            currentTime -= Time.deltaTime;
            knifeRange.gameObject.SetActive(false);

            // Check if the countdown is finished
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isCountingDown = false;

                // Trigger an event or perform an action when the countdown finishes
                
                knifeRange.gameObject.SetActive(true);

                // Start the pause timer
                Invoke("StartCountdown", pauseDuration);
            }
        }
    }

    private void StartCountdown()
    {
        // Reset the timer for the next countdown
        currentTime = countdownDuration;
        isCountingDown = true;

        // Perform any actions needed before starting the countdown again
        
    }
}

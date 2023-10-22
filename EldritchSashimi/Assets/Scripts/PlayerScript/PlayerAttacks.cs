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
    [SerializeField] private GameObject ChopstickRange;
    [SerializeField] private GameObject KatanaRange;
    [SerializeField] private GameObject TridentRange;
    public int WeaponID;

    private void Start()
    {
        // Start the countdown
        currentTime = countdownDuration;
        WeaponID = 1;
    }

    private void Update()
    {
        switch (WeaponID)
        {
            case 1:

                Knife();

             break;

           case 2:

                Chopstick();

            break;

            case 3:

                Katana();

            break;

            case 4:

             Trident();

            break;
        }
    }

    private void StartCountdown()
    {
        // Reset the timer for the next countdown
        currentTime = countdownDuration;
        isCountingDown = true;

        // Perform any actions needed before starting the countdown again
        
    }


    private void Knife()
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

    private void Chopstick()
    {
        if (isCountingDown)
        {
            // Update the countdown timer
            currentTime -= Time.deltaTime;
            ChopstickRange.gameObject.SetActive(false);

            // Check if the countdown is finished
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isCountingDown = false;

                // Trigger an event or perform an action when the countdown finishes

                ChopstickRange.gameObject.SetActive(true);

                // Start the pause timer
                Invoke("StartCountdown", pauseDuration);
            }
        }
    }

    private void Katana()
    {
        if (isCountingDown)
        {
            // Update the countdown timer
            currentTime -= Time.deltaTime;
            KatanaRange.gameObject.SetActive(false);

            // Check if the countdown is finished
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isCountingDown = false;

                // Trigger an event or perform an action when the countdown finishes

                KatanaRange.gameObject.SetActive(true);

                // Start the pause timer
                Invoke("StartCountdown", pauseDuration);
            }
        }
    }

    private void Trident()
    {
        if (isCountingDown)
        {
            // Update the countdown timer
            currentTime -= Time.deltaTime;
            TridentRange.gameObject.SetActive(false);

            // Check if the countdown is finished
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isCountingDown = false;

                // Trigger an event or perform an action when the countdown finishes

                TridentRange.gameObject.SetActive(true);

                // Start the pause timer
                Invoke("StartCountdown", pauseDuration);
            }
        }
    }
}

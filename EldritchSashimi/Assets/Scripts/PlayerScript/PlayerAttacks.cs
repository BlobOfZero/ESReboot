using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacks : MonoBehaviour
{

    public float knifecountdownDuration = 5f;
    public float katanacountdownDuration = 5f;
    public float chopstickcountdownDuration = 5f;
    public float tridentcountdownDuration = 5f;
    public float pauseDuration = 2f;

    [SerializeField] private ParticleSystem KnifeSlash;
    private float currentTime;
    private bool isCountingDown = true;
    [SerializeField] private GameObject knifeRange;
    [SerializeField] private GameObject ChopstickRange;
    [SerializeField] private GameObject KatanaRange;
    [SerializeField] private GameObject TridentRange;
    public GameObject knife;
    public GameObject chopsticks;
    public GameObject katana;
    public GameObject trident;

    public int WeaponID;

    private void Start()
    {
        // Start the countdown
        currentTime = knifecountdownDuration;
        WeaponID = 1;
    }

    private void Update()
    {
        switch (WeaponID)
        {
            case 1:
             Knife();
             knife.gameObject.SetActive(true);
             katana.gameObject.SetActive(false);
             chopsticks.gameObject.SetActive(false);
             trident.gameObject.SetActive(false);
            break;

           case 2:
            Chopstick();
            chopsticks.gameObject.SetActive(true);
            knife.gameObject.SetActive(false);
            trident.gameObject.SetActive(false);
            katana.gameObject.SetActive(false);
           break;

            case 3:
             Katana();
             katana.gameObject.SetActive(true);
             trident.gameObject.SetActive(false);
             knife.gameObject.SetActive(false);
             chopsticks.gameObject.SetActive(false);
            break;

            case 4:
             Trident();
             trident.gameObject.SetActive(true);
             chopsticks.gameObject.SetActive(false);
             knife.gameObject.SetActive(false);
             katana.gameObject.SetActive(false);
            break;
        }
    }

    private void StartCountdownKnife()
    {
        // Reset the timer for the next countdown
        currentTime = knifecountdownDuration;
        isCountingDown = true;

        // Perform any actions needed before starting the countdown again
        
    }

    private void StartCountdownKatana()
    {
        // Reset the timer for the next countdown
        currentTime = katanacountdownDuration;
        isCountingDown = true;

        // Perform any actions needed before starting the countdown again

    }

    private void StartCountdownChopstick()
    {
        // Reset the timer for the next countdown
        currentTime = chopstickcountdownDuration;
        isCountingDown = true;

        // Perform any actions needed before starting the countdown again

    }

    private void StartCountdownTrident()
    {
        // Reset the timer for the next countdown
        currentTime = tridentcountdownDuration;
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
                KnifeSlash.Play();
                // Start the pause timer
                Invoke("StartCountdownKnife", pauseDuration);
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
                Invoke("StartCountdownChopstick", pauseDuration);
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
                Invoke("katanacountdownDuration", pauseDuration);
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
                Invoke("StartCountdownTrident", pauseDuration);
            }
        }
    }
}

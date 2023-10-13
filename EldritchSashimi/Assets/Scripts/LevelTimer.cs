using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [Header("Timer variables")]
    //**********************************
    public GameObject shopUI;
    [SerializeField] private TextMeshProUGUI coinText;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    //**********************************

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        shopUI.SetActive(false);
        
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                shopUI.SetActive (true);
                timeRemaining = 0;
                timerIsRunning = false;
                Time.timeScale = 0;
            }
        }
    }

    public void LeaveeShop()
    {
        shopUI.SetActive(false);
        Time.timeScale = 1;
    }
}

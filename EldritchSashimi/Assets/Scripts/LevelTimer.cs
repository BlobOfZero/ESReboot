using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    [Header("Timer variables")]
    //**********************************
    public GameObject shopUI;
    [SerializeField] private TextMeshProUGUI coinText;
    public float timeRemaining;
    public float maxTime = 10;
    public bool timerIsRunning = false;
    public GameManager manager;

    public TextMeshProUGUI timerText;
    //**********************************

    // death variables
    public GameObject GameOverUI;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timeRemaining = maxTime;
        shopUI.SetActive(false);
        timerText.text = timeRemaining.ToString("0.0");
        GameOverUI.SetActive(false);
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
        timerText.text = timeRemaining.ToString("0.0");
    }

    public void NextLevel()
    {
        shopUI.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void FinalLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void leaveShop()
    {    
        shopUI.SetActive(false);
        Time.timeScale = 1;
        timerIsRunning = true;
        timeRemaining = maxTime;
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }
}

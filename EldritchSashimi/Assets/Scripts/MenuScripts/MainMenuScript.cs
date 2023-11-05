using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject LevelSelectPanel;
    public PlayerData data;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        MainPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
        source = GetComponent<AudioSource>();
        source.Play();
    }

   public void PlayGame()
    {
        SceneManager.LoadScene("ShallowsK");
        data.playerCoins = 0;
    }

   public void LevelSelect()
    {
        LevelSelectPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void Back()
    {
        LevelSelectPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject OptionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        MainPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }

   public void PlayGame()
    {
        SceneManager.LoadScene("Shallows");
    }

   public void Options()
    {
        OptionsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void Back()
    {
        OptionsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}

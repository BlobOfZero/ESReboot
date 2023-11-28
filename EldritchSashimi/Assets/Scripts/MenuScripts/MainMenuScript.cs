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
    [SerializeField] private GameObject creditsPanel;
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
        data.playerCoins = 1000;
        data.playerWeaponID = 1;
        data.playerAttackWeaponID = 1;
    }

    public void CRLevel1()
    {
        SceneManager.LoadScene("ShallowsCR");
        data.playerCoins = 0;
        data.playerWeaponID = 1;
        data.playerAttackWeaponID = 1;
    }

    public void CRLevel2()
    {
        SceneManager.LoadScene("ReefCR");
        data.playerCoins = 0;
        data.playerWeaponID = 1;
        data.playerAttackWeaponID = 1;
    }

    public void CRLevel3()
    {
        SceneManager.LoadScene("DepthsCR");
        data.playerCoins = 0;
        data.playerWeaponID = 1;
        data.playerAttackWeaponID = 1;
    }

    public void DLC()
    {
        SceneManager.LoadScene("DLC");
        data.playerCoins = 0;
        data.playerWeaponID = 1;
        data.playerAttackWeaponID = 1;
    }

    public void LevelSelect()
    {
        LevelSelectPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void CreditsBack()
    {
        creditsPanel.SetActive(false);
        MainPanel.SetActive(true);
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

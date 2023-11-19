using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public PlayerData data;

    public void LoadShallows()
    {
        SceneManager.LoadScene("ShallowsK");
        data.playerCoins = 0;
    }

    public void LoadReef()
    {
        SceneManager.LoadScene("Level2Temp");
        data.playerCoins = 0;
    }

    public void LoadDepths()
    {
        SceneManager.LoadScene("FinalBoss");
        data.playerCoins = 0;
    }
}

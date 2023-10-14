using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public static GameManager instance;
     public int playerCoins;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinText.text = "Coins: " + playerCoins.ToString();
    }

    public void IncreaseCoins(int value)
    {
        playerCoins += value;
        coinText.text = "Coins: " + playerCoins.ToString();
    }
}

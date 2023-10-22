using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public static GameManager instance;
    public PlayerData data;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinText.text = "Coins: " + data.playerCoins.ToString();
    }

    public void IncreaseCoins(int value)
    {
        data.playerCoins += value;
        coinText.text = "Coins: " + data.playerCoins.ToString();
    }
    public void DecreaseCoins(int value)
    {
        data.playerCoins -= value;
        coinText.text = "Coins: " + data.playerCoins.ToString();
    }
}

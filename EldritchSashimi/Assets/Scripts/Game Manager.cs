using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    [SerializeField] private int playerCoins;
    // Start is called before the first frame update
    void Start()
    {
        playerCoins = 0;
        coinText.text = "Coins: " + playerCoins;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + playerCoins;
    }

    public void IncreaseCoins(int coins)
    {
        playerCoins += coins;
    }
}

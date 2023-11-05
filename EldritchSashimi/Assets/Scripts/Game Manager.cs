using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public static GameManager instance;
    public PlayerData data;
    AudioSource source;
    public AudioClip clip;
   

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        coinText.text = "Tentacles: " + data.playerCoins.ToString();
        data.playerAttackWeaponID = data.playerAttackWeaponID;
        data.playerWeaponID = data.playerWeaponID;
        source.Play();
    }

    public void IncreaseCoins(int value)
    {
        data.playerCoins += value;
        coinText.text = "Tentacles: " + data.playerCoins.ToString();
    }
    public void DecreaseCoins(int value)
    {
        data.playerCoins -= value;
        coinText.text = "Tentacles: " + data.playerCoins.ToString();
    }
}

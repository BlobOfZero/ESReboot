using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ShopScript : MonoBehaviour
{
    public PlayerData data;
    public AudioSource purchaseAudio;
    public GameManager manager;
    private PlayerController PC;
    private PlayerAttacks PA;
    private float dashBuffLimit;
    private float specialBuffLimit;
    private float ultimateBuffLimit;
    AudioSource source;
    public AudioClip clip;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI tridentText;
    public TextMeshProUGUI chopstickText;
    public TextMeshProUGUI katanaText;
    public int costTrident;
    public int costChopstick;
    public int costKatana;
    [SerializeField] private Image statusOfPurchaseTrident1;
    [SerializeField] private Image statusOfPurchaseTrident2;
    [SerializeField] private Image statusOfPurchaseTrident3;
    [SerializeField] private Image statusOfPurchaseChopstick1;
    [SerializeField] private Image statusOfPurchaseChopstick2;
    [SerializeField] private Image statusOfPurchaseChopstick3;
    [SerializeField] private Image statusOfPurchaseKatana1;
    [SerializeField] private Image statusOfPurchaseKatana2;
    [SerializeField] private Image statusOfPurchaseKatana3;
    //trident stuff
    //****************************************
    private float TridentBuff;
    private float tridentPurchases;
    //****************************************

    //Chopstick stuff
    //****************************************
    private float ChopstickBuff;
    private float chopstickPurchases;
    //****************************************

    //Katana stuff
    //****************************************
    private float KatanaBuff;
    private float katanaPurchases;
    //****************************************

    private void Start()  
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PA = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacks>();
        source = manager.GetComponent<AudioSource>();

        statusOfPurchaseTrident1.gameObject.SetActive(false);
        statusOfPurchaseTrident2.gameObject.SetActive(false);
        statusOfPurchaseTrident3.gameObject.SetActive(false);

        statusOfPurchaseChopstick1.gameObject.SetActive(false);
        statusOfPurchaseChopstick2.gameObject.SetActive(false);
        statusOfPurchaseChopstick3.gameObject.SetActive(false);

        statusOfPurchaseKatana1.gameObject.SetActive(false);
        statusOfPurchaseKatana2.gameObject.SetActive(false);
        statusOfPurchaseKatana3.gameObject.SetActive(false);

    }

    private void Update()
    {
       coinText.text = data.playerCoins.ToString();
        katanaText.text = "" +costKatana.ToString();
        tridentText.text = "" + costTrident.ToString();
        chopstickText.text = "" + costChopstick.ToString();
    }
    public void OnPurchaseDashBuff()
    {
        
        if ((data.playerCoins >= 100) && (dashBuffLimit <= 2))
        {
            dashBuffLimit += 1;
            PC.cooldowndashTime -= 0.5f;
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
            coinText.text = data.playerCoins.ToString();
        }
        else return;
    }


    public void OnPurchaseSpecialBuff()
    {
        if ((data.playerCoins >= 100) && (specialBuffLimit <= 3))
        {
            specialBuffLimit += 1;
            PC.cooldownTimeSpecial -= 0.5f;
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
            coinText.text = data.playerCoins.ToString();
        }
        else return;
    }


    public void OnPurchaseUltimateBuff()
    {
        if ((data.playerCoins >= 100) && (ultimateBuffLimit <= 3))
        {
            ultimateBuffLimit += 1;
            PC.cooldownTimeUltimate -= 0.5f;
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
            coinText.text = data.playerCoins.ToString();
        }
        else return;
    }

    public void TridentPurchase()
    {
        if ((data.playerCoins >= costTrident) && TridentBuff <= 2)
        {
            manager.DecreaseCoins(costTrident);
            TridentBuff += 1;
            tridentPurchases += 1;
            source.PlayOneShot(clip);

            switch (tridentPurchases) 
            {
                case 1:
                    Debug.Log("bruh");
                    PA.WeaponID = 4;
                    PC.WeaponIDs = 4;
                    data.playerAttackWeaponID = 4;
                    data.playerWeaponID = 4;
                    costTrident += 100;
                    coinText.text = data.playerCoins.ToString();
                    statusOfPurchaseTrident1.gameObject.SetActive(true);
                    break;

                case 2:
                    Debug.Log("lul");
                    PA.tridentcountdownDuration -= 0.125f;
                    costTrident += 100;
                    coinText.text = data.playerCoins.ToString();                
                    statusOfPurchaseTrident2.gameObject.SetActive(true);
                    break;

                case 3:
                    Debug.Log("ha");
                    PA.tridentcountdownDuration -= 0.125f;
                    costTrident += 100;
                    coinText.text = data.playerCoins.ToString();                  
                    statusOfPurchaseTrident3.gameObject.SetActive(true);
                    break;
            }
        }
           
    }

    public void ChopstickPurchase()
    {
        if ((data.playerCoins >= costChopstick) && ChopstickBuff  <= 2)
        {
            
            manager.DecreaseCoins(costChopstick);
            ChopstickBuff += 1;
           chopstickPurchases += 1;
            source.PlayOneShot(clip);

            switch (chopstickPurchases)
            {
                case 1:
                    Debug.Log("bruh");
                    PA.WeaponID = 2;
                    PC.WeaponIDs = 2;
                    data.playerAttackWeaponID = 2;
                    data.playerWeaponID = 2;
                    costChopstick += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    statusOfPurchaseChopstick1.gameObject.SetActive(true);
                    break;

                case 2:
                    Debug.Log("lul");
                    PA.chopstickcountdownDuration -= 0.25f;
                    costChopstick += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    statusOfPurchaseChopstick2.gameObject.SetActive(true);
                    break;

                case 3:
                    Debug.Log("ha");
                    PA.chopstickcountdownDuration -= 0.25f;
                    costChopstick += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    statusOfPurchaseChopstick3.gameObject.SetActive(true);
                    break;
            }
        }
           
    }

    public void KatanaPurchase()
    {
        if ((data.playerCoins >= costKatana) && KatanaBuff <= 2)
        {
            
            manager.DecreaseCoins(costKatana);
            KatanaBuff += 1;
            katanaPurchases += 1;
            source.PlayOneShot(clip);

            switch (katanaPurchases)
            {
                case 1:
                    Debug.Log("bruh");
                    PA.WeaponID = 3;
                    PC.WeaponIDs = 3;
                    data.playerAttackWeaponID = 3;
                    data.playerWeaponID = 3;
                    costKatana += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    statusOfPurchaseKatana1.gameObject.SetActive(true);
                    break;

                case 2:
                    Debug.Log("lul");
                    PA.katanacountdownDuration -= 0.25f;
                    costKatana += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    statusOfPurchaseKatana2.gameObject.SetActive(true);
                    break;

                case 3:
                    Debug.Log("ha");
                    PA.katanacountdownDuration -= 0.25f;
                    costKatana += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    statusOfPurchaseKatana3.gameObject.SetActive(true);
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
        
    }

    private void Update()
    {
       coinText.text = "Tentacles: " + data.playerCoins.ToString();
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
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
            coinText.text = "Tentacles: " + data.playerCoins.ToString();
        }
        else return;
    }


    public void OnPurchaseSpecialBuff()
    {
        if ((data.playerCoins >= 100) && (specialBuffLimit <= 3))
        {
            specialBuffLimit += 1;
            PC.cooldownTimeSpecial -= 0.5f;
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
            coinText.text = "Tentacles: " + data.playerCoins.ToString();
        }
        else return;
    }


    public void OnPurchaseUltimateBuff()
    {
        if ((data.playerCoins >= 100) && (ultimateBuffLimit <= 3))
        {
            ultimateBuffLimit += 1;
            PC.cooldownTimeUltimate -= 0.5f;
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
            coinText.text = "Tentacles: " + data.playerCoins.ToString();
        }
        else return;
    }

    public void TridentPurchase()
    {
        if ((data.playerCoins >= costTrident) && TridentBuff <= 4)
        {
            purchaseAudio.Play();
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
                    PA.isWeaponSwitching = true;
                    data.playerAttackWeaponID = 4;
                    data.playerWeaponID = 4;
                    costTrident += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                break;

                case 2:
                    Debug.Log("lul");
                    PA.tridentcountdownDuration -= 0.125f;
                    costTrident += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                break;

                case 3:
                    Debug.Log("ha");
                    PA.tridentcountdownDuration -= 0.125f;
                    costTrident += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                break;
            }
        }
           
    }

    public void ChopstickPurchase()
    {
        if ((data.playerCoins >= costChopstick) && ChopstickBuff  <= 4)
        {
            
            purchaseAudio.Play();
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
                    break;

                case 2:
                    Debug.Log("lul");
                    PA.chopstickcountdownDuration -= 0.25f;
                    costChopstick += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    break;

                case 3:
                    Debug.Log("ha");
                    PA.chopstickcountdownDuration -= 0.25f;
                    costChopstick += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    break;
            }
        }
           
    }

    public void KatanaPurchase()
    {
        if ((data.playerCoins >= costKatana) && KatanaBuff <= 4)
        {
            
            purchaseAudio.Play();
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
                    break;

                case 2:
                    Debug.Log("lul");
                    PA.katanacountdownDuration -= 0.25f;
                    costKatana += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    break;

                case 3:
                    Debug.Log("ha");
                    PA.katanacountdownDuration -= 0.25f;
                    costKatana += 100;
                    coinText.text = "Tentacles: " + data.playerCoins.ToString();
                    break;
            }
        }
    }
}

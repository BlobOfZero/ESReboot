using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShopScript : MonoBehaviour
{
    public PlayerData data;
    public AudioSource purchaseAudio;
    public GameManager manager;
    private PlayerController PC;
    private PlayerAttacks PA;
    private float DashBuffLimit;
    private float SpecialBuffLimit;
    private float UltimateBuffLimit;
    AudioSource source;
    public AudioClip clip;

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

    public void OnPurchaseDashBuff()
    {
        
        if ((data.playerCoins >= 100) && (DashBuffLimit <= 2))
        {
            DashBuffLimit += 1;
            PC.cooldowndashTime -= 0.5f;
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
        }
        else return;
    }


    public void OnPurchaseSpecialBuff()
    {
        if ((data.playerCoins >= 100) && (SpecialBuffLimit <= 3))
        {
            SpecialBuffLimit += 1;
            PC.cooldownTimeSpecial -= 0.5f;
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
        }
        else return;
    }


    public void OnPurchaseUltimateBuff()
    {
        if ((data.playerCoins >= 100) && (SpecialBuffLimit <= 3))
        {
            UltimateBuffLimit += 1;
            PC.cooldownTimeUltimate -= 0.5f;
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
            source.PlayOneShot(clip);
        }
        else return;
    }

    public void TridentPurchase()
    {
        if ((data.playerCoins >= 100) && TridentBuff <= 4)
        {
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
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
                break;

                case 2:
                    Debug.Log("lul");
                    PA.tridentcountdownDuration -= 2;
                break;

                case 3:
                    Debug.Log("ha");
                    PA.tridentcountdownDuration -= 1;
                break;
            }
        }
           
    }

    public void ChopstickPurchase()
    {
        if ((data.playerCoins >= 100) && ChopstickBuff  <= 4)
        {
            
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
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
                    break;

                case 2:
                    Debug.Log("lul");
                    PA.chopstickcountdownDuration -= 0.25f;
                    break;

                case 3:
                    Debug.Log("ha");
                    PA.chopstickcountdownDuration -= 0.25f;
                    break;
            }
        }
           
    }

    public void KatanaPurchase()
    {
        if ((data.playerCoins >= 100) && KatanaBuff <= 4)
        {
            
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
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
                    break;

                case 2:
                    Debug.Log("lul");
                    PA.katanacountdownDuration -= 1.5f;
                    break;

                case 3:
                    Debug.Log("ha");
                    PA.katanacountdownDuration -= 1;
                    break;
            }
        }
    }
}

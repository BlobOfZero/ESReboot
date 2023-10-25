using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void OnPurchaseDashBuff()
    {
        
        if ((data.playerCoins >= 100) && (DashBuffLimit <= 2))
        {
            DashBuffLimit += 1;
            PC.cooldowndashTime -= 0.5f;
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
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

            switch (tridentPurchases) 
            {
                case 1:
                    Debug.Log("bruh");
                    PA.WeaponID = 4;
                break;

                case 2:
                    Debug.Log("lul");
                break;

                case 3:
                    Debug.Log("ha");
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
            switch (chopstickPurchases)
            {
                case 1:
                    Debug.Log("bruh");
                    PA.WeaponID = 2;
                    break;

                case 2:
                    Debug.Log("lul");
                    break;

                case 3:
                    Debug.Log("ha");
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

            switch (katanaPurchases)
            {
                case 1:
                    Debug.Log("bruh");
                    PA.WeaponID = 3;
                    break;

                case 2:
                    Debug.Log("lul");
                    break;

                case 3:
                    Debug.Log("ha");
                    break;
            }
        }
    }
}

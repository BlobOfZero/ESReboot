using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public AudioSource purchaseAudio;
    public GameManager manager;
    private PlayerController PC;
    private PlayerAttacks PA;
    private float DashBuffLimit;
    private float SpecialBuffLimit;
    private float UltimateBuffLimit;


    private void Start()  
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PA = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacks>();
    }

    public void OnPurchaseDashBuff()
    {
        
        if ((manager.playerCoins >= 100) && (DashBuffLimit <= 2))
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
        if ((manager.playerCoins >= 100) && (SpecialBuffLimit <= 3))
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
        if ((manager.playerCoins >= 100) && (SpecialBuffLimit <= 3))
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
        PA.WeaponID = 4;
        purchaseAudio.Play();
        manager.DecreaseCoins(100);
    }
}

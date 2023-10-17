using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public AudioSource purchaseAudio;
    public GameManager manager;
    private PlayerController PC;
    private float DashBuffLimit;


    private void Start()  
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
    public void OnPurchaseAttackSpeedBuff()
    {
        if ((manager.playerCoins >= 100))
        {
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
        }
        else return;
    }
    public void OnPurchaseBuff()
    {
        if ((manager.playerCoins >= 100))
        {
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
        }
        else return;
    }
}

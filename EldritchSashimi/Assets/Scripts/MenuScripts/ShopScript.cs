using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public AudioSource purchaseAudio;
    public GameManager manager;

    public void OnPurchase()
    {
        if ((manager.playerCoins >= 100))
        {
            purchaseAudio.Play();
            manager.DecreaseCoins(100);
        }
        else return;
    }
}

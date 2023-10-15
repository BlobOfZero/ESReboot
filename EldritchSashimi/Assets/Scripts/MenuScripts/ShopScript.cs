using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public AudioSource purchaseAudio;

    public void OnPurchase()
    {
        purchaseAudio.Play();
    }
}

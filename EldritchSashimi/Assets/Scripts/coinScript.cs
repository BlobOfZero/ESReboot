using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coin collected");
            Destroy(gameObject);
            GameManager.instance.IncreaseCoins(value);
        }
    }
}

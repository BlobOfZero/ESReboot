using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentUltimate : MonoBehaviour
{    
    [SerializeField] private GameObject tridentExplosion;

    void OnCollisionEnter(Collision other)
    {
        GameObject tridentBullet = Instantiate(tridentExplosion,transform.position, transform.rotation);
        Destroy(gameObject);       
    }
}

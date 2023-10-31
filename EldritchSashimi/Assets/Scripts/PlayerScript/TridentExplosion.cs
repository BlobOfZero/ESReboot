using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentExplosion : MonoBehaviour
{
    public float lifetime;
    public float tridentExplosionDamage;
   
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable Damage))
        {
            Damage.Damage(tridentExplosionDamage);
        }
    }
}

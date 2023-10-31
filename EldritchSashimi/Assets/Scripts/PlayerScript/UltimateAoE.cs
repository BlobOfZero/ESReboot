using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEDamage : MonoBehaviour
{
    [SerializeField] private float ultimateDamage;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable Damage))
        {
            Damage.Damage(ultimateDamage);

        }
    }
}

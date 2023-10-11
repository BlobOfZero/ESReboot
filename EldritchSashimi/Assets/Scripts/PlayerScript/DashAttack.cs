using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    [SerializeField] private float dashDamage;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable Damage))
        {
            Damage.Damage(dashDamage);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float enemyDamage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageablePlayer Damage))
        {
            Damage.DamagePlayer(enemyDamage);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour, IDamageablePlayer
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            DamagePlayer(1);
        }
    }

    public void DamagePlayer(float damageAmount)
    {

    }
}

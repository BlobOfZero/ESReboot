using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float damage;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IDamageablePlayer DamagePlayer))
        {
            DamagePlayer.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}
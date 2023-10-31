using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentSpecial : MonoBehaviour
{
    public float tridentSpecialDamage;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable Damage))
        {
            Damage.Damage(tridentSpecialDamage);

        }
    }
}

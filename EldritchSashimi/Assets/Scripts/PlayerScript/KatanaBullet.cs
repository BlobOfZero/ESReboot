using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaBullet : MonoBehaviour
{
    public float lifetime;
    public float katanaDamage;
    [SerializeField] private ParticleSystem katanaSlash;

    void Start()
    {
        Destroy(gameObject, lifetime);
        //katanaSlash.Play();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable Damage))
        {
            Damage.Damage(katanaDamage);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

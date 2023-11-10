using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickRotate : MonoBehaviour
{
    [SerializeField] private float chopstickUltimateDamage;
    [SerializeField] private float chopstickRotationSpeed;
    [SerializeField] private GameObject origin;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), chopstickRotationSpeed * Time.deltaTime);
    }
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable Damage))
        {
            Damage.Damage(chopstickUltimateDamage);

        }
    }
}

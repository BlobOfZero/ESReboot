using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRanged : MonoBehaviour, IDamageable
{
    public NavMeshAgent agent;

    public Transform player;

    public float speed;

    [SerializeField] private LayerMask WhatIsPlayer;

    [SerializeField] private bool IsChasing;

    [SerializeField] private bool IsAttacking;

    [SerializeField] private bool PlayerInAttackRange;

    [SerializeField] private float AttackRange;

    [SerializeField] private float RunAwayDistance;

    [SerializeField] private GameObject Projectile;

    [SerializeField] private float RateOfAttacks;

    [SerializeField] private GameObject firepoint;

    [SerializeField] private float health = 3;

    void awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayerInRange();
        TooClose();
        death();
    }



    void TooClose()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < RunAwayDistance)
        {
            Vector3 dirtoPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirtoPlayer;
            agent.SetDestination(newPos);
        }
    }

    void AttackPlayerInRange()
    {
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

        if (!PlayerInAttackRange)
        {
            Chasing();
        }

        if (PlayerInAttackRange)
        {
            Attacking();
        }
    }

    void Chasing()
    {
        if (IsChasing)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > AttackRange)
            {
                Vector3 dirtoPlayer = transform.position + player.transform.position;
                Vector3 newPos = transform.position - dirtoPlayer;
                agent.SetDestination(newPos);
            }
        }
        IsChasing = true;
        transform.LookAt(player);
    }


    private void Attacking()
    {
        transform.LookAt(player);
        if (IsAttacking != true)
        {
            //attack code here
            Rigidbody rb = Instantiate(Projectile, firepoint.transform.position, firepoint.transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

            //
            Invoke(nameof(ResetAttack), RateOfAttacks);
            IsAttacking = true;
            //audioSource.clip = attackclip;
            //audioSource.Play();
            IsChasing = false;
        }

    }

    private void ResetAttack()
    {
        IsAttacking = false;
    }

    public void Damage(float damageAmount)
    {
        Debug.Log("Enemy damaged for" + damageAmount);
        health -= damageAmount;
    }

    void death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
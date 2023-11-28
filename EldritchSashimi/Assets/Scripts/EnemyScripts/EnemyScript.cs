using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyScript : MonoBehaviour, IDamageable
{
    public NavMeshAgent agent;

    public Transform player;

    public float speed;

    [SerializeField] private LayerMask WhatIsPlayer;

    [SerializeField] private bool IsChasing;

    [SerializeField] private bool IsAttacking;

    [SerializeField] private bool PlayerInAttackRange;

    [SerializeField] private float AttackRange;

    public float health = 10;

    [SerializeField] private float Maxhealth = 10;

    [SerializeField] FloatingHealthbar healthBar;

    // Coin prefab for drop
    public GameObject coinPrefab;

    // audio
    AudioSource source;
    [SerializeField] private AudioClip clip;

    //playerdata refrence
    public PlayerData data;

    //DLC
    [Header("DLC")]
    public bool dlcInstalledEnemy;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        healthBar = GetComponentInChildren<FloatingHealthbar>();
        source = GetComponent<AudioSource>();

        dlcInstalledEnemy = data.playerDLCInstalled;

        if (dlcInstalledEnemy)
        {
            Debug.Log("dlc installed enemy");
        }
    }


    // Update is called once per frame
    void Update()
    {
        AttackPlayerInRange();
        death();

        
    }

    void AttackPlayerInRange()
    {
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

        if (!PlayerInAttackRange)
        {
            IsAttacking = false;
            IsChasing = true;
            Chasing();
        }

        if (PlayerInAttackRange)
        {
            IsChasing = false;
            IsAttacking = true;
        }
    }

    void Chasing()
    {
        if (IsChasing)
        {
            agent.SetDestination(player.position);
        }
        // transform.LookAt(player);
    }

    public void Damage(float damageAmount)
    {
        Debug.Log("Enemy damaged for" + damageAmount);
        health -= damageAmount;
        source.PlayOneShot(clip, 0.1f);
        healthBar.UpdateHealthbar(health , Maxhealth);
    }

    void death()
    {
        if (health <= 0)
        {
           
            Destroy(gameObject);
            Instantiate(coinPrefab, transform.position, transform.rotation);
        }
    }
}
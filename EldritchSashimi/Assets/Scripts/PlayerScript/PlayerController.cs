using UnityEngine;
using System.Collections;
using  System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour, IDamageablePlayer
{
    [Header("Movement Variables")]
    //**********************************************************
    public float speed;
    private Vector2 move;
    public CharacterController controller;
    //**********************************************************

    [Header("health")]
    //**********************************************************
    public float maxHealth;
    public float currentHealth;
    bool isDead;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] LevelTimer timer;
    //**********************************************************

    [Header("player data refrence")]
    public PlayerData data;
    //**********************************************************

    public Transform firepoint;
    public float bulletspeed;

    [Header("Regular Dash")]
    //**********************************************************
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    public float cooldowndashTime;
    [SerializeField] private float nextdashTime;
    [SerializeField] private ParticleSystem RegularDash;
    //**********************************************************

    [Header("Special/Ultimate cooldowns")]
    //**********************************************************
    public float cooldownTimeSpecial;
    public float cooldownTimeUltimate;
    [SerializeField] private float nextFireTimeSpecial;
    [SerializeField] private float nextFireTimeUltimate;
    //**********************************************************

    [Header("for special knife")]
    //**********************************************************
    [SerializeField] private float dashAttackSpeed;
    [SerializeField] private float dashAttackTime;
    [SerializeField] private GameObject dashAttack;
    [SerializeField] private ParticleSystem Special1;
    //**********************************************************

    [Header("ultimate knife")]
    //**********************************************************
    [SerializeField] private GameObject ultimateAttack;
    [SerializeField] private float ultimateknifetime;
    [SerializeField] private ParticleSystem Ultimate1;
    //**********************************************************

    [Header("for special chopsticks")]
    //**********************************************************
    [SerializeField] private float chopstickSpecialTime;
    [SerializeField] private GameObject chopstickSpecial;
    [SerializeField] private ParticleSystem specialChopstick;
    //**********************************************************

    [Header("ultimate chopsticks")]
    //**********************************************************
    [SerializeField] private GameObject ultimateAttackChopstick;
    [SerializeField] private float ultimateChopstickTime;
    [SerializeField] private ParticleSystem ultimateChopstick;
    //**********************************************************

    [Header("for special trident")]
    //**********************************************************
    [SerializeField] private float tridentSpecialTime;
    [SerializeField] private GameObject tridentSpecial;
    [SerializeField] private ParticleSystem tridentChopstick;
    //**********************************************************

    [Header("ultimate trident")]
    //**********************************************************
    [SerializeField] private GameObject ultimateAttackTrident;
    [SerializeField] private float ultimateTridentTime;
    [SerializeField] private ParticleSystem ultimateTrident;
    private bool canFireTridentUltimate;
    //**********************************************************


    [Header("for special katana")]
    //**********************************************************
    [SerializeField] private GameObject specialAttackKatana;
    [SerializeField] private float specialKatanaTime;
    [SerializeField] private ParticleSystem specialKatana;
    private bool canFireKatanaSpecial; 
    //**********************************************************

    [Header("ultimate katana")]
    //**********************************************************
    [SerializeField] private float katanaUltimateTime;
    [SerializeField] private GameObject ultimateAttackKatana;
    [SerializeField] private ParticleSystem katana;
    //**********************************************************


    [Header("Id's for special/ultimate moves")]
    //**********************************************************
    public int WeaponIDs;
    //**********************************************************

    [Header("Inputs")]
    //**********************************************************
    public InputActionAsset actions;
    //**********************************************************

    //refrences
    //**********************************************************
    private KnifeAttack knifeattack;
    //**********************************************************

    void OnEnable()
    {
        actions.FindActionMap("Player").FindAction("Dash").performed += OnDash;
        actions.FindActionMap("Player").FindAction("Special").performed += OnSpecial;
        actions.FindActionMap("Player").FindAction("Ultimate").performed += OnUltimate;
    }
    void OnDisable()
    {
        actions.FindActionMap("Player").FindAction("Dash").performed -= OnDash;
        actions.FindActionMap("Player").FindAction("Special").performed -= OnSpecial;
        actions.FindActionMap("Player").FindAction("Ultimate").performed -= OnUltimate;
    }

    void Awake() 
    {
        WeaponIDs = data.playerAttackWeaponID;
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        maxHealth = 10;
        currentHealth = maxHealth;      
        isDead = false;
        knifeattack = GetComponent<KnifeAttack>();        
        Time.timeScale = 1;
        isDead = false;
        healthText.text = "Current health: " + currentHealth;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (Time.time > nextdashTime)
        {
            StartCoroutine(Dash());
            nextdashTime = Time.time + cooldowndashTime;
            RegularDash.Play();
        }
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        switch (WeaponIDs)
        {
            case 1:

                if (Time.time > nextFireTimeSpecial)
                {

                    Debug.Log("special move1");
                    StartCoroutine(DashAttack());
                    nextFireTimeSpecial = Time.time + cooldownTimeSpecial;
                    Special1.Play();
                }
                break;

            case 2:

                if (Time.time > nextFireTimeSpecial)
                {
                    Debug.Log("special move2");
                    StartCoroutine(ChopstickSpecialMove());
                    nextFireTimeSpecial = Time.time + cooldownTimeSpecial;
                    //the particle is going to get commented out as there is no particles for it at the current momment 
                    //specialChopstick.Play();
                }
                break;

            case 3:

                if (Time.time > nextFireTimeSpecial)
                {
                    Debug.Log("special move3");
                    StartCoroutine(KatanaSpecialMove()); 
                     nextFireTimeSpecial = Time.time + cooldownTimeSpecial;
                    //the particle is going to get commented out as there is no particles for it at the current momment 
                    //specialChopstick.Play();  <-- this is going to be something else obviously
                }
                break;

            case 4:

                if (Time.time > nextFireTimeSpecial)
                {
                    Debug.Log("special move3");
                    StartCoroutine(TridentSpecialMove());
                    nextFireTimeSpecial = Time.time + cooldownTimeSpecial;
                    //the particle is going to get commented out as there is no particles for it at the current momment 
                    //specialChopstick.Play(); <-- this is going to be something else obviously
                }
                break;
        }




    }

    public void OnUltimate(InputAction.CallbackContext context)
    {
        switch (WeaponIDs)
        {
            case 1:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move1");
                    StartCoroutine(KnifeUltimate());
                    nextFireTimeUltimate = Time.time + cooldownTimeUltimate;
                    Ultimate1.Play();
                }
                break;

            case 2:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move2");
                    StartCoroutine(ChopstickUltimateMove());
                    nextFireTimeUltimate = Time.time + cooldownTimeUltimate;
                    //this is commented because we don't have the particles for it
                    //ultimateChopstick.Play();

                }
                break;

            case 3:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move3");
                    StartCoroutine(KatanaUltimateMove());
                    nextFireTimeUltimate = Time.time + cooldownTimeUltimate;                    
                }
                break;

            case 4:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move4");
                    StartCoroutine(TridentUltimateMove()); 
                    nextFireTimeUltimate = Time.time + cooldownTimeUltimate;
                }
                break;
        }
    }

    

    private void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        controller.Move(movement * speed * Time.deltaTime);
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {         
            controller.Move(transform.forward * dashSpeed * Time.deltaTime);
            yield return null;
        }      
    }

    //Knife abilities
    //**********************************************
    IEnumerator DashAttack()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashAttackTime) 
        {
            dashAttack.gameObject.SetActive(true);
            controller.Move(transform.forward * dashAttackSpeed * Time.deltaTime);
            yield return null;
        }
        dashAttack.gameObject.SetActive(false);
    }

    IEnumerator KnifeUltimate()
    {
        float startTime = Time.time;
        while (Time.time < startTime + ultimateknifetime)
        {
            ultimateAttack.gameObject.SetActive(true);            
            yield return null;
        }
       ultimateAttack.gameObject.SetActive(false);
    }
    //**********************************************

    //Chopstick abilities
    //**********************************************
    IEnumerator ChopstickSpecialMove()
    {
        float startTime = Time.time;
        while (Time.time < startTime + chopstickSpecialTime)
        {
            chopstickSpecial.gameObject.SetActive(true);

            yield return null;
        }
        chopstickSpecial.gameObject.SetActive(false);
    }

    IEnumerator ChopstickUltimateMove()
    {
        float startTime = Time.time;
        while (Time.time < startTime + ultimateChopstickTime)
        {
            ultimateAttackChopstick.gameObject.SetActive(true);

            yield return null;
        }
        ultimateAttackChopstick.gameObject.SetActive(false);
    }
    //**********************************************

    //Trident abilities
    //**********************************************
    IEnumerator TridentSpecialMove()
    {
        float startTime = Time.time;
        while (Time.time < startTime + tridentSpecialTime)
        {
            tridentSpecial.gameObject.SetActive(true);

            yield return null;
        }
        tridentSpecial.gameObject.SetActive(false);
    }

    IEnumerator TridentUltimateMove()
    {
        Rigidbody rb = Instantiate(ultimateAttackTrident, firepoint.transform.position, firepoint.transform.rotation).GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward * bulletspeed, ForceMode.Impulse);     
        yield return null;              
    }
    //**********************************************

    //Katana abilities
    //**********************************************
    IEnumerator KatanaSpecialMove()
    {
        Rigidbody rb = Instantiate(specialAttackKatana, firepoint.transform.position, firepoint.transform.rotation).GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward * bulletspeed, ForceMode.Impulse);
        yield return null;
    }

    IEnumerator KatanaUltimateMove()
    {

        float startTime = Time.time;
        while (Time.time < startTime + katanaUltimateTime)
        {
            ultimateAttackKatana.gameObject.SetActive(true);

            yield return null;
        }
        ultimateAttackKatana.gameObject.SetActive(false);
    }
    //**********************************************

    //this is from the IdamageablePlayer Interface
    //************************************************
    public void DamagePlayer(float damageAmount)
    {
     currentHealth -= damageAmount;
     healthText.text = "Current health: " + currentHealth;

      if (currentHealth <= 0) 
      {
       isDead = true;
       Destroy(gameObject);
       Time.timeScale = 0;
        timer.GameOver();
      }
    }
   //************************************************
}

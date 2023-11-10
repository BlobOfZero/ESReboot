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
    private bool isDashing;
    public float cooldowndashTime;
    [SerializeField] private float nextdashTime;
    [SerializeField] private ParticleSystem RegularDash;
    [SerializeField] private Image imageCooldownDash;
    private bool iFrames;
    //**********************************************************

    [Header("Special/Ultimate cooldowns")]
    //**********************************************************
    public float cooldownTimeSpecial;
    public float cooldownTimeUltimate;
    private bool isSpecialAttacking;
    private bool isUltimateAttacking;
    [SerializeField] private float nextFireTimeSpecial;
    [SerializeField] private float nextFireTimeUltimate;
    [SerializeField] private Image imageCooldownSpecial;
    [SerializeField] private Image imageCooldownUltimate;
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
    public int WeaponIDs = 1;
    //**********************************************************

    [Header("Inputs")]
    //**********************************************************
    public InputActionAsset actions;
    //**********************************************************

    [Header("Player Sounds")]
    AudioSource source;
    [SerializeField] private AudioClip dashClip;
    [SerializeField] private AudioClip slashClip;

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

    private void Update()
    {
        MovePlayer();


        if (isDashing)
        {
            ApplyDashCooldown();
        }
        
        if (isSpecialAttacking) 
        {
            ApplySpecialCoolDown();
        }

        if (isUltimateAttacking) 
        {
            ApplyUltimateCooldown();
        }
    }

    void ApplyDashCooldown()
    {
        nextdashTime -= Time.deltaTime;

        if (nextdashTime <= 0.0f)
        {
            isDashing = false;
            imageCooldownDash.fillAmount = 0.0f;
        }
        else
        {            
            imageCooldownDash.fillAmount = nextdashTime/cooldowndashTime;
        }
    }

    void ApplyUltimateCooldown()
    {
       nextFireTimeUltimate -= Time.deltaTime;

        if (nextFireTimeUltimate <= 0.0f)
        {
            isDashing = false;
            imageCooldownUltimate.fillAmount = 0.0f;
        }
        else
        {
            imageCooldownUltimate.fillAmount = nextFireTimeUltimate / cooldownTimeUltimate;
        }
    }

    void ApplySpecialCoolDown()
    {
        nextFireTimeSpecial -= Time.deltaTime;

        if (nextFireTimeSpecial <= 0.0f)
        {
            isDashing = false;
            imageCooldownSpecial.fillAmount = 0.0f;
        }
        else
        {
            imageCooldownSpecial.fillAmount = nextFireTimeSpecial / cooldownTimeSpecial;
        }
    }

    void Awake() 
    {
        WeaponIDs = data.playerWeaponID;
        data.playerWeaponID = WeaponIDs;       
        source = GetComponent<AudioSource>();       
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
        isDashing = false;
        isSpecialAttacking = false;
        isUltimateAttacking = false;
        healthText.text = "Current health: " + currentHealth;
        iFrames = false;
        imageCooldownDash.fillAmount = 0.0f;
        imageCooldownSpecial.fillAmount = 0.0f;
        imageCooldownUltimate.fillAmount = 0.0f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (Time.deltaTime > nextdashTime)
        {
            StartCoroutine(Dash());
            nextdashTime = Time.deltaTime + cooldowndashTime;
            RegularDash.Play();
            source.PlayOneShot(dashClip);
            isDashing = true;
        }       
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        switch (WeaponIDs)
        {
            case 1:

                if (Time.deltaTime > nextFireTimeSpecial)
                {

                    Debug.Log("special move1");
                    StartCoroutine(DashAttack());
                    nextFireTimeSpecial = Time.deltaTime + cooldownTimeSpecial;
                    Special1.Play();
                    isSpecialAttacking = true;
                }
                break;

            case 2:

                if (Time.deltaTime > nextFireTimeSpecial)
                {
                    Debug.Log("special move2");
                    StartCoroutine(ChopstickSpecialMove());
                    nextFireTimeSpecial = Time.deltaTime + cooldownTimeSpecial;
                    //the particle is going to get commented out as there is no particles for it at the current momment 
                    //specialChopstick.Play();
                    isSpecialAttacking = true;
                }
                break;

            case 3:

                if (Time.deltaTime > nextFireTimeSpecial)
                {
                    Debug.Log("special move3");
                    StartCoroutine(KatanaSpecialMove()); 
                     nextFireTimeSpecial = Time.deltaTime + cooldownTimeSpecial;
                    //the particle is going to get commented out as there is no particles for it at the current momment 
                    //specialChopstick.Play();  <-- this is going to be something else obviously
                    isSpecialAttacking = true;
                }
                break;

            case 4:

                if (Time.deltaTime > nextFireTimeSpecial)
                {
                    Debug.Log("special move3");
                    StartCoroutine(TridentSpecialMove());
                    nextFireTimeSpecial = Time.deltaTime + cooldownTimeSpecial;
                    //the particle is going to get commented out as there is no particles for it at the current momment 
                    //specialChopstick.Play(); <-- this is going to be something else obviously
                    isSpecialAttacking = true;
                }
                break;
        }




    }

    public void OnUltimate(InputAction.CallbackContext context)
    {
        switch (WeaponIDs)
        {
            case 1:
                if (Time.deltaTime > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move1");
                    StartCoroutine(KnifeUltimate());
                    nextFireTimeUltimate = Time.deltaTime + cooldownTimeUltimate;
                    Ultimate1.Play();
                    isUltimateAttacking = true;
                }
                break;

            case 2:
                if (Time.deltaTime > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move2");
                    StartCoroutine(ChopstickUltimateMove());
                    nextFireTimeUltimate = Time.deltaTime + cooldownTimeUltimate;
                    //this is commented because we don't have the particles for it
                    //ultimateChopstick.Play();
                    isUltimateAttacking = true;
                }
                break;

            case 3:
                if (Time.deltaTime > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move3");
                    StartCoroutine(KatanaUltimateMove());
                    nextFireTimeUltimate = Time.deltaTime + cooldownTimeUltimate;
                    isUltimateAttacking = true;
                }
                break;

            case 4:
                if (Time.deltaTime > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move4");
                    StartCoroutine(TridentUltimateMove()); 
                    nextFireTimeUltimate = Time.deltaTime + cooldownTimeUltimate;
                    isUltimateAttacking = true;
                }
                break;
        }
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
            iFrames = true;           
            yield return null;
        }
        iFrames = false;
    }

    //Knife abilities
    //**********************************************
    IEnumerator DashAttack()
    {
        source.PlayOneShot(slashClip);
        float startTime = Time.time;
        while (Time.time < startTime + dashAttackTime) 
        {
            dashAttack.gameObject.SetActive(true);
            controller.Move(transform.forward * dashAttackSpeed * Time.deltaTime);
            iFrames = true;
            
            yield return null;
        }
        dashAttack.gameObject.SetActive(false);
        iFrames = false;
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
        if (!iFrames)
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
    
    }
   //************************************************
}

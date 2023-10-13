using UnityEngine;
using System.Collections;
using  System.Collections.Generic;
using UnityEngine.InputSystem;

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
    [SerializeField] private float health;
    //**********************************************************

    [Header("Regular Dash")]
    //**********************************************************
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float cooldowndashTime;
    [SerializeField] private float nextdashTime;
    //**********************************************************

    [Header("Special/Ultimate cooldowns")]
    //**********************************************************
    [SerializeField] private float cooldownTimeSpecial;
    [SerializeField] private float cooldownTimeUltimate;
    [SerializeField] private float nextFireTimeSpecial;
    [SerializeField] private float nextFireTimeUltimate;
    //**********************************************************

    [Header("for special 1")]
    //**********************************************************
    [SerializeField] private float dashAttackSpeed;
    [SerializeField] private float dashAttackTime;
    [SerializeField] private GameObject dashAttack;
    //**********************************************************

    [Header("ultimate 1 variables")]
    //**********************************************************
    [SerializeField] private GameObject ultimateAttack;
    [SerializeField] private float ultimateknifetime;
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

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        health = 3;
        knifeattack = GetComponent<KnifeAttack>();
        actions.FindActionMap("Player").FindAction("Dash").performed += OnDash;
        actions.FindActionMap("Player").FindAction("Special").performed += OnSpecial;
        actions.FindActionMap("Player").FindAction("Ultimate").performed += OnUltimate;
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
                }
                break;

            case 2:

                if (Time.time > nextFireTimeSpecial)
                {
                    Debug.Log("special move2");

                    nextFireTimeSpecial = Time.time + cooldownTimeSpecial;
                }
                break;

            case 3:

                if (Time.time > nextFireTimeSpecial)
                {
                    Debug.Log("special move3");

                    nextFireTimeSpecial = Time.time + cooldownTimeSpecial;
                }
                break;

            case 4:

                if (Time.time > nextFireTimeSpecial)
                {
                    Debug.Log("special move4");

                    nextFireTimeSpecial = Time.time + cooldownTimeSpecial;
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
                }
                break;

            case 2:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move2");
                    nextFireTimeUltimate = Time.time + cooldownTimeUltimate;
                }
                break;

            case 3:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move3");
                    nextFireTimeUltimate = Time.time + cooldownTimeUltimate;
                }
                break;

            case 4:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move4");
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

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game quit");
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
        //this is from the IdamageablePlayer Interface
        //************************************************
        public void DamagePlayer(float damageAmount)
    {
        health -= damageAmount;
    }
   //************************************************
}

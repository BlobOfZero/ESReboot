using UnityEngine;
using System.Collections;
using  System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamageablePlayer
{
    public float speed;
    private Vector2 move;
    public CharacterController controller;

    [SerializeField] private float health;

    [SerializeField] private float cooldownTimeSpecial;
    [SerializeField] private float cooldownTimeUltimate;
    [SerializeField] private float nextFireTimeSpecial;
    [SerializeField] private float nextFireTimeUltimate;


    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
     public int SpecialMoves;
     public int UltimateMoves;
     public InputActionAsset actions;
    

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        health = 3;
        actions.FindActionMap("Player").FindAction("Special").performed += OnSpecial;
        actions.FindActionMap("Player").FindAction("Ultimate").performed += OnUltimate;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        switch (SpecialMoves)
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
        switch (UltimateMoves)
        {
            case 1:
                if (Time.time > nextFireTimeUltimate)
                {
                    Debug.Log("ultimate move1");
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

    IEnumerator DashAttack()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime) 
        {
            controller.Move(transform.forward * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }

    //this is from the IdamageablePlayer Interface
    //************************************************
    public void DamagePlayer(float damageAmount)
    {
        health -= damageAmount;
    }
   //************************************************
}

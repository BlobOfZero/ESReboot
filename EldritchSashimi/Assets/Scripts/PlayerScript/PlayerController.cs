using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamageablePlayer
{
    public float speed;
    private Vector2 move;
    public CharacterController controller;

    [SerializeField] private float health;

    [SerializeField] private float CooldownTimeSpecial;
    [SerializeField] private float CooldownTimeUltimate;
    [SerializeField] private float nextFireTimeSpecial;
    [SerializeField] private float nextFireTimeUltimate;

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
        if (Time.time > nextFireTimeSpecial)
        {
            Debug.Log("special move");
            nextFireTimeSpecial = Time.time + CooldownTimeSpecial;
        }
        
    }

    public void OnUltimate(InputAction.CallbackContext context)
    {
        if (Time.time > nextFireTimeUltimate)
        {
            Debug.Log("ultimate move");
            nextFireTimeUltimate = Time.time + CooldownTimeUltimate;
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

    public void DamagePlayer(float damageAmount)
    {
        health -= damageAmount;
    }
}

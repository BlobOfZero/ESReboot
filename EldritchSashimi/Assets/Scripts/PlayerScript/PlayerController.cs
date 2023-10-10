using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamageablePlayer
{
    public float speed;
    private Vector2 move;
    public CharacterController controller;

    [SerializeField] private float health;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        health = 3;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
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

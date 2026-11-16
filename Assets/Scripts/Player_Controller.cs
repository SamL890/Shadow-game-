using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [Header("Player Objects")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Movement Settings")]
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] private Vector2 playerInput; // Gets current movement of the player
    [SerializeField] public float playerSpeed;
    [SerializeField] public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get RigidBody at start of program
    }

    public void Move(InputAction.CallbackContext ctx) //allows the player to move
    {
        playerInput = ctx.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = playerInput * playerSpeed;
    }
}

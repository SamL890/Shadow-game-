using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static Dictionary<string, Vector3> pos = new();

    [Header("Player Objects")]
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    private float moveInput;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Scene scene = SceneManager.GetActiveScene();
        if (pos.TryGetValue(scene.name, out Vector3 position))
        {
            transform.position = position;
        }
    }

    private void OnDestroy()
    {
        Scene scene = SceneManager.GetActiveScene();
        pos[scene.name] = transform.position;
    }

    public void OnMove(InputAction.CallbackContext ctx) // Move Method
    {
        moveInput = ctx.ReadValue<Vector2>().x; // Get the current direction the player is moving, Ex: Pressing Left would return -1, while pressing right would return 1

        if (moveInput > 0) // Flip Sprite if facing a certain direction
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;
    }

    public void OnJump(InputAction.CallbackContext ctx) // Jump Method
    {
        if (ctx.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void FixedUpdate() // Movement
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}

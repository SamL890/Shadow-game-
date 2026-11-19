using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static Dictionary<string, Vector3> pos = new();

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool isGrounded;

    public SpriteRenderer spriteRenderer;

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

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>().x;

        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}

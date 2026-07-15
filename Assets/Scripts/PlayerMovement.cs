using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;

    public Vector2 MoveInput => moveInput;

    public bool IsMoving => moveInput != Vector2.zero;
    public float FacingDirection => spriteRenderer.flipX ? 1f : 1f;

    public bool CanMove = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!CanMove) return;
        
        rb.linearVelocity = moveInput * speed;

        HandleFlip();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void StopMovement()
    {
        moveInput = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
    }

    void HandleFlip()
    {
        if (moveInput.x == 0) return;

        spriteRenderer.flipX = moveInput.x < 0;
    }
}

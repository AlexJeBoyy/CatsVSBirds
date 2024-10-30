using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    private float moveSpeed = 5;
    public Animator animator; 

    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPreformed;
        input.Player.Movement.canceled += OnMovementCancelled;
        animator.SetBool("isMoving", true);
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPreformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
        animator.SetBool("isMoving", false);
    }
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
        AnimatorMovement(moveVector);
    }
    private void OnMovementPreformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    void AnimatorMovement(Vector2 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}

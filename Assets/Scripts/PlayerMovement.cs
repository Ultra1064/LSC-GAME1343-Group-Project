using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private IA_Player moveAction;

    private void Awake()
    {
        moveAction = new IA_Player();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        moveAction.Enable();
        moveAction.Player.Skill1.performed += OnSkill1;
        moveAction.Player.Skill2.performed += OnSkill2;
        moveAction.Player.Skill3.performed += OnSkill3;
    }
    private void OnDisable()
    {
        moveAction.Player.Skill2.performed -= OnSkill2;
        moveAction.Player.Skill3.performed -= OnSkill3;
        moveAction.Player.Skill1.performed -= OnSkill1;
        moveAction.Disable();
    }
    private void OnSkill1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            Debug.Log("Used Skill One");
    }
    private void OnSkill2(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            Debug.Log("Used Skill Two");
    }
    private void OnSkill3(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            Debug.Log("Used Skill Two");
    }
    private void FixedUpdate()
    {
        moveInput = moveAction.Player.Move.ReadValue<Vector2>();
        rb.linearVelocity = moveInput * moveSpeed;
    }
}

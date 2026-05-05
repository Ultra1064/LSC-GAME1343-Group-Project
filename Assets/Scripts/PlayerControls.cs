using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float timeBetweenDashes = .2f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private IA_Player moveAction;
    private bool dashing;
    private float timeAfterDashing;

    private void Awake()
    {
        moveAction = new IA_Player();
        rb = GetComponent<Rigidbody2D>();
        timeAfterDashing = timeBetweenDashes;
    }
    private void OnEnable()
    {
        moveAction.Enable();
        moveAction.Player.Skill1.performed += OnSkill1;
        moveAction.Player.Skill2.performed += OnSkill2;
        moveAction.Player.Skill3.performed += OnSkill3;
        moveAction.Player.Dash.performed += OnDash;
    }
    private void OnDisable()
    {
        moveAction.Player.Dash.performed -= OnDash;
        moveAction.Player.Skill2.performed -= OnSkill2;
        moveAction.Player.Skill3.performed -= OnSkill3;
        moveAction.Player.Skill1.performed -= OnSkill1;
        moveAction.Disable();
    }
    private void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !dashing)
        {
            dashing = true;
            Debug.Log("Dashed!");
            rb.AddForce(moveInput * dashSpeed, ForceMode2D.Impulse);
        }
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
        if (!dashing)
        {
            moveInput = moveAction.Player.Move.ReadValue<Vector2>();
            rb.linearVelocity = moveInput * moveSpeed;
        }
        else
        {
            timeAfterDashing -= Time.deltaTime;
            if (timeAfterDashing <= 0)
            {
                dashing = false;
                timeAfterDashing = timeBetweenDashes;
            }
        }
    }
}

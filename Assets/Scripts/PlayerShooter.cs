using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject barrelEnd;
    [SerializeField] float timeBetweenBullets = 1f;

    private float timeAfterShooting;
    private IA_Player moveAction;
    private bool shooting = false;
    private void Awake()
    {
        moveAction = new IA_Player();
        timeAfterShooting = timeBetweenBullets;
    }
    
    private void OnEnable()
    {
        moveAction.Enable();
        moveAction.Player.Fire.performed += OnFire;
        moveAction.Player.Fire.canceled += OffFire;
    }
    private void OnDisable()
    {
        moveAction.Player.Fire.performed -= OnFire;
        moveAction.Player.Fire.performed -= OffFire;
    }
    private void OnFire(InputAction.CallbackContext ctx)
    {
        shooting = true;
    }
    private void OffFire(InputAction.CallbackContext ctx)
    {
        shooting = false;
    }
    private void FixedUpdate()
    {
        if (shooting && timeAfterShooting >= timeBetweenBullets)
            Shoot();
        else
            timeAfterShooting += Time.deltaTime;
    }
    private void Shoot()
    {
        timeAfterShooting = 0;
        Vector2 position = barrelEnd.transform.position;
        Quaternion rotation = barrelEnd.transform.rotation;
        Instantiate(bullet, position, rotation);
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    // References
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject barrelEndRight;
    [SerializeField] GameObject barrelEndLeft;
    [SerializeField] float timeBetweenBullets = 1f;

    // Variables
    private float timeAfterShooting;
    private IA_Player moveAction;
    private bool shooting = false;
    private bool facingLeft = false;

    // Power Up Flags
    private bool increasedFireRate = false;

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
    public void OnFlip(bool flipped)
    {
        facingLeft = flipped;
    }
    private void Shoot()
    {
        timeAfterShooting = 0;
        Vector2 position;
        Quaternion rotation;
        if (facingLeft)
        {
            
            position = barrelEndLeft.transform.position;
            rotation = barrelEndLeft.transform.rotation;
        }
        else
        {
            position = barrelEndRight.transform.position;
            rotation = barrelEndRight.transform.rotation;
        }
        Instantiate(bullet, position, rotation);
    }
    public void DivideFireRate(float amount)
    {
        timeBetweenBullets /= amount;
    }
    public void IncreasedFireRate()
    {
        increasedFireRate = true;
    }
    private void HigherFireRate()
    {
        // float currFireRatePowerUpTimer = 0;
    }
    private void FixedUpdate()
    {
        if (increasedFireRate)
        {
            HigherFireRate();
        }
        if (shooting && timeAfterShooting >= timeBetweenBullets)
            Shoot();
        else
            timeAfterShooting += Time.deltaTime;
    }
}
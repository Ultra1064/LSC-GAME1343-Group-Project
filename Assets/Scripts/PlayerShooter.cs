using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    // References
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject barrelEnd;
    [SerializeField] float timeBetweenBullets = 1f;

    // Variables
    private float timeAfterShooting;
    private IA_Player moveAction;
    private bool shooting = false;

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
    
    private void Shoot()
    {
        timeAfterShooting = 0;
        Vector2 position = barrelEnd.transform.position;
        Quaternion rotation = barrelEnd.transform.rotation;
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
        //static float currFireRatePowerUpTimer = 0;
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
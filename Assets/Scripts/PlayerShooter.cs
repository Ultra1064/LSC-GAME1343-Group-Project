using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerShooter : MonoBehaviour
{
    // References
    [Header("References")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject barrelEndRight;
    [SerializeField] GameObject barrelEndLeft;
    [SerializeField] CharacterLookAtMouse playerLooking;
    [SerializeField] LineRenderer lineRenderer;

    // Weapon Stats
    [Header("Weapon Stats and Timers")]
    [SerializeField] int laserDamage = 10;
    [SerializeField] float timeBetweenBullets = 1f;
    [SerializeField] float shotgunTimer = 10f;
    [SerializeField] float laserTimer = 5f;

    // Unity Events
    private UnityEvent<RaycastHit2D> LaserHit;

    // Variables
    private float timeAfterShooting;
    private IA_Player moveAction;
    private bool shooting = false;
    private bool flipped = false;
    private float laserDistance = 30f;

    // Power Up Flags
    private bool shotgunOn = false;
    private bool laserOn = false;

    // Power Up Timers
    private float currShotgunTimer = 10f;
    private float currLaserTimer = 5f;

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
        moveAction.Disable();
    }
    private void FixedUpdate()
    {
        if (shooting && timeAfterShooting >= timeBetweenBullets)
            Shoot();
        else
            lineRenderer.enabled = false;
        if (currShotgunTimer >= shotgunTimer)
        {
            currShotgunTimer = shotgunTimer;
            shotgunOn = false;
        }
        if (currLaserTimer >= laserTimer)
        {
            currLaserTimer = laserTimer;
            laserOn = false;
        }
        if (timeAfterShooting >= timeBetweenBullets)
            timeAfterShooting = timeBetweenBullets;

        currShotgunTimer += Time.deltaTime;
        currLaserTimer += Time.deltaTime;
        timeAfterShooting += Time.deltaTime;
    }
    private void OnFire(InputAction.CallbackContext ctx)
    {
        shooting = true;
    }
    private void OffFire(InputAction.CallbackContext ctx)
    {
        shooting = false;
    }
    public void IsFlipped(bool flipped)
    {
        this.flipped = flipped;
    }
    private void Shoot()
    {
        if (laserOn)
        {
            lineRenderer.enabled = true;
            if (flipped)
            {
                lineRenderer.SetPosition(0, barrelEndLeft.transform.position);
            }
            else
            {
                lineRenderer.SetPosition(0, barrelEndRight.transform.position);
            }
            Vector2 direction = (playerLooking.GetMousePosition() - (Vector2)transform.position).normalized;
            Vector2 endPoint = (Vector2)transform.position + (direction * laserDistance);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, laserDistance);
            
            if (hit.collider != null)
            {
                endPoint = hit.point;
                if (hit.collider.gameObject.GetComponent<EnemyIdentifier>() != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyHealthSystem>().DecreaseHealth(laserDamage);
                }
            }
            
            lineRenderer.SetPosition(1, endPoint);
        }
        else
        {
            timeAfterShooting = 0;

            Vector2 position;
            Quaternion rotation;

            if (flipped)
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
            if (shotgunOn)
            {
                Instantiate(bullet, position, rotation * Quaternion.Euler(0, 0, 10));
                Instantiate(bullet, position, rotation * Quaternion.Euler(0, 0, -10));
                Instantiate(bullet, position, rotation * Quaternion.Euler(0, 0, 20));
                Instantiate(bullet, position, rotation * Quaternion.Euler(0, 0, -20));
            }
        }
    }
    public void IncreasedFireRate()
    {
        timeBetweenBullets /= 1.5f;
    }
    public void ShotgunOn()
    {
        shotgunOn = true;
        currShotgunTimer = 0f;
    }
    public void LaserOn()
    {
        laserOn = true;
        currLaserTimer = 0f;
    }
}
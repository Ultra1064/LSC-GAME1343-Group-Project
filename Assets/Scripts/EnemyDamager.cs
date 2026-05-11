using UnityEngine;
using UnityEngine.Events;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] int enemyDamage = 10;
    [SerializeField] float enemyDamageCooldown = 3f;

    private UnityEvent<int> OnDamaged = new UnityEvent<int>();
    private float timeSinceLastDamaged = 0;

    private HealthSystem playerHealth;
    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealthSystem>();
        OnDamaged.AddListener(playerHealth.DecreaseHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null && timeSinceLastDamaged >= enemyDamageCooldown)
        {
            OnDamaged.Invoke(enemyDamage);
            timeSinceLastDamaged = 0;
        }
    }
    private void FixedUpdate()
    {
        timeSinceLastDamaged += Time.deltaTime;
        if (timeSinceLastDamaged >= enemyDamageCooldown)
            timeSinceLastDamaged = enemyDamageCooldown;
    }
}

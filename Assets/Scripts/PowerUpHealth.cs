using UnityEngine;
using UnityEngine.Events;

public class PowerUpHealth : PowerUp
{
    private UnityEvent<int> HealthUp = new UnityEvent<int>();
    private PlayerHealthSystem player;
    [SerializeField] int healthIncrease = 10;

    protected override void Awake()
    {
        player = FindFirstObjectByType<PlayerHealthSystem>();
        HealthUp.AddListener(player.IncreaseHealth);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null)
        {
            if (HealthUp != null)
                HealthUp.Invoke(healthIncrease);
            Destroy(gameObject);
        }
    }
}
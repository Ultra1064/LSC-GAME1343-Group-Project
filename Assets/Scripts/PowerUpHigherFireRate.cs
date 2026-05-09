using UnityEngine;
using UnityEngine.Events;

public class PowerUpHigherFireRate : PowerUp
{
    private UnityEvent IncreaseFireRate = new UnityEvent();
    private PlayerShooter player;
    protected override void Awake()
    {
        player = FindFirstObjectByType<PlayerShooter>();
        IncreaseFireRate.AddListener(player.IncreasedFireRate);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShooter>() == player)
        {
            if (IncreaseFireRate != null)
                IncreaseFireRate.Invoke();
            Destroy(gameObject);
        }
    }
}
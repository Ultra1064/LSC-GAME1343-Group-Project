using UnityEngine;
using UnityEngine.Events;

public class PowerUpHigherFireRate : PowerUp
{
    private UnityEvent IncreaseFireRate = new UnityEvent();
    private PlayerShooter player;
    protected override void Awake()
    {
        player = FindAnyObjectByType<PlayerShooter>();
        IncreaseFireRate.AddListener(player.IncreasedFireRate);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerShooter>() == player)
        {
            source.PlayOneShot(get);
            if (IncreaseFireRate != null)
                IncreaseFireRate.Invoke();
            Destroy(gameObject);
        }
    }
}
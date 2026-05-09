using UnityEngine;
using UnityEngine.Events;

public class PowerUpLaser : PowerUp
{
    private UnityEvent LaserOn = new UnityEvent();
    private PlayerShooter player;

    protected override void Awake()
    {
        player = FindFirstObjectByType<PlayerShooter>();
        LaserOn.AddListener(player.LaserOn);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null)
        {
            if (LaserOn != null)
                LaserOn.Invoke();
            Destroy(gameObject);
        }
    }
}
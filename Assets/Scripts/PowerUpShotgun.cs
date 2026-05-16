using UnityEngine;
using UnityEngine.Events;

public class PowerUpShotgun : PowerUp
{
    private UnityEvent ShotgunOn = new UnityEvent();
    private PlayerShooter player;

    protected override void Awake()
    {
        player = FindFirstObjectByType<PlayerShooter>();
        ShotgunOn.AddListener(player.ShotgunOn);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null)
        {
            source.PlayOneShot(get);
            if (ShotgunOn != null)
                ShotgunOn.Invoke();
            Destroy(gameObject);
        }
    }
}
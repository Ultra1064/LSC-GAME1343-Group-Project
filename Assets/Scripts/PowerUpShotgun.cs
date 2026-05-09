using UnityEngine;
using UnityEngine.Events;

public class PowerUpShotgun : PowerUp
{
    private UnityEvent ShotgunOn;

    protected override void Awake()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null)
        {
            if (ShotgunOn != null)
                ShotgunOn.Invoke();
            Destroy(gameObject);
        }
    }
}
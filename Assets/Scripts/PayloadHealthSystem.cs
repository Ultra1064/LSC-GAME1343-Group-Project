using UnityEngine;

public class PayloadHealthSystem : HealthSystem
{
    AudioSource source;
    [SerializeField] AudioClip gotHit;
    [SerializeField] AudioClip destroyed;

    protected override void Start()
    {
        source = Object.FindFirstObjectByType<AudioSource>(); //Needed to add this for sound
        health = maxHealth;
    }
    protected override void FixedUpdate()
    {
        timeSinceLastDamaged += Time.deltaTime;
        if (timeSinceLastDamaged >= damagedCooldown)
            timeSinceLastDamaged = damagedCooldown;
        Debug.Log("Payload health: " + health);
    }

    public override void DecreaseHealth(int health)
    {
        if (timeSinceLastDamaged >= damagedCooldown)
        {
            timeSinceLastDamaged = 0;
            source.PlayOneShot(gotHit);
            this.health -= health;
        }
    }
}
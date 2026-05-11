using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    public override void DecreaseHealth(int health)
    {
        if (timeSinceLastDamaged >= damagedCooldown)
        {
            timeSinceLastDamaged = 0;
            this.health -= health;
        }
    }

    public override int GetHealth()
    {
        return health;
    }

    public override void IncreaseHealth(int health)
    {
        this.health += health;
    }

    protected override void Start()
    {
        health = maxHealth;
    }
}

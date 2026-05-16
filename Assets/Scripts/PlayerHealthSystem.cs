using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    protected override void Start()
    {
        health = maxHealth;
    }
    public override void IncreaseHealth(int health)
    {
        if (health < maxHealth)
            this.health += health;
        Debug.Log("PlayerIncreasedHealth");
    }
}
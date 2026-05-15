using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{
    protected override void Start()
    {
        health = maxHealth;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
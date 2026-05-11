using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    protected override void Start()
    {
        health = maxHealth;
    }
}
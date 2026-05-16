using UnityEngine;

public class PayloadHealthSystem : HealthSystem
{
    protected override void FixedUpdate()
    {
        timeSinceLastDamaged += Time.deltaTime;
        if (timeSinceLastDamaged >= damagedCooldown)
            timeSinceLastDamaged = damagedCooldown;
        Debug.Log("Payload health: " + health);
    }
}
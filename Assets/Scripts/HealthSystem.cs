using Unity.VisualScripting;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float damagedCooldown = 2f;

    protected int health;
    protected float timeSinceLastDamaged;
    protected virtual void Start()
    {
        health = maxHealth;
    }
    protected virtual void FixedUpdate()
    {
        timeSinceLastDamaged += Time.deltaTime;
        if (timeSinceLastDamaged >= damagedCooldown)
            timeSinceLastDamaged = damagedCooldown;
        Debug.Log("Current health: " + health);
    }
    public virtual void DecreaseHealth(int health)
    {
        if (timeSinceLastDamaged >= damagedCooldown)
        {
            timeSinceLastDamaged = 0;
            this.health -= health;
        }
    }
    public virtual void IncreaseHealth(int health)
    {
        this.health += health;
    }
    public virtual int GetHealth()
    {
        return health;
    }
}
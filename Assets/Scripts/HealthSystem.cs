using Unity.VisualScripting;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float damagedCooldown = 2f;

    protected int health;
    protected float timeSinceLastDamaged;
    protected abstract void Start();
    protected virtual void FixedUpdate()
    {
        timeSinceLastDamaged += Time.deltaTime;
        if (timeSinceLastDamaged >= damagedCooldown)
            timeSinceLastDamaged = damagedCooldown;
        Debug.Log(health);
    }
    public abstract void DecreaseHealth(int health);
    public abstract void IncreaseHealth(int health);
    public abstract int GetHealth();
}

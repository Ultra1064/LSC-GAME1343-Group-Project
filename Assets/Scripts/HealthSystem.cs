using Unity.VisualScripting;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float damagedCooldown = 2f;

    [SerializeField] private Sprite[] JeepGood;
    [SerializeField] private Sprite[] JeepDamaged;

    [SerializeField] private SpriteRenderer jeepSpriteRenderer;

    [SerializeField] private Sprite[] HealthBarSprites;
    [SerializeField] private SpriteRenderer healthBarSpriteRenderer;

    [SerializeField] private Sprite[] JeepHealthSprites;
    [SerializeField] private SpriteRenderer jeepHealthSpriteRenderer;



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
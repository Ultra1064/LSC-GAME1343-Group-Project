using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour //I would've had this inherit from the HealthSystem, but I realized virtual functions always exist, as they are defaults. The enemies don't need an update function for their health, so I'm creating a new one.
{
    [SerializeField] private int maxHealth;

    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    public void IncreaseHealth(int health)
    {
        this.health += health;
        if(this.health > maxHealth)
        {
            this.health = maxHealth;
        }
    }

    public void DecreaseHealth(int health)
    {
        this.health -= health;
    }

    public int GetHealth()
    {
        return this.health;
    }
}

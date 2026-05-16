using Unity.VisualScripting;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float damagedCooldown = 2f;

    [SerializeField] GameObject GAMEOVER;
    [SerializeField] GameObject PAUSED;
    [SerializeField] GameObject RETRY;
    [SerializeField] GameObject QUIT;
    protected bool Gameover = false;



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

        if (health <= 0 && !Gameover)
        {
            Gameover = true;
            if (Gameover == true)
            {
                GAMEOVER.SetActive(true);
                QUIT.SetActive(true);
                RETRY.SetActive(true);
                PAUSED.SetActive(false);
                Time.timeScale = 0f;
            }

        }
        else
        {
            GAMEOVER.SetActive(false);
            QUIT.SetActive(false);
            RETRY.SetActive(false);
            Time.timeScale = 1f;
        }
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
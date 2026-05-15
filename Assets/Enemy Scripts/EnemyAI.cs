using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float knockbackValue = 1f;
    [SerializeField] private int damageValue = 1;
    [SerializeField] public Transform target;
    [SerializeField] States state;
    SpriteRenderer sr;
    Rigidbody rb;
    EnemyHealthSystem healthSystem;
    EnemyFlash flash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = States.alive;
        rb = GetComponent<Rigidbody>();
        healthSystem = GetComponent<EnemyHealthSystem>();
        flash = GetComponent<EnemyFlash>();
        sr = GetComponentInChildren<SpriteRenderer>(); //This grabs the Sprite Renderer on the 2D object.
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.alive:
                UpdateAlive();
                break;
            case States.dead:
                UpdateDead();
                break;
        }
    }

    void UpdateAlive()
    {
        if (target != null)
        {
            if (target.position.x < transform.position.x) //This checks if the target is to the left of the enemy
            {
                sr.flipX = true; //If it is, then it flips the sprite!
            }
            else
            {
                sr.flipX = false; //If it isn't, it returns to normal!
            }
            // Calculate direction vector
            Vector2 direction = (target.position - transform.position).normalized;

            // Move towards target
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    void UpdateDead()
    {
        speed = 0f; //Stops the enemy
        float deathTimer = 0;
        deathTimer += Time.deltaTime; //Keeps track of how long the enemy was dead for
        if (deathTimer >= GetComponent<EnemyFlash>().deathDuration) //Once the animation is finished, enemy is removed from play
        {
            Destroy(gameObject);
        }
    }

    private void Knockback(int weaponKnockback)
    {
        Vector2 away = (transform.position - target.position).normalized; //This is flipped from the direction vector in UpdateAlive()
        rb.AddForce(weaponKnockback * knockbackValue * away, ForceMode.Impulse); //ForceMode.Force is consistent, Impulse is a burst.
    } //The force is calculated by the knockback value of the enemy, plus the knockback value of the weapon that hit it

    /*
    void calculateSpeed() //IGNORE THIS //NOT USING THIS ANYMORE
    {
        Need a way to calculate speed based on speed of payload/camera. Enemies from the front might reach the payload too quickly, while as enemies from the back
        may not catch up.

        To calculate this, I will need the speed of the payload, and add it's speed to the speed of enemies behind it to simulate as if they're moving normally.
        For example, if the payload has a speed of 5, an enemy chasing it needs a speed of 6 to look as if it has a speed of 1. An enemy in FRONT of the payload,
        needs a speed of 4 in the OPPOSITE direction to look as if it has a speed of 1 moving towards the payload. If it's adjacent to the payload, it needs to match
        the horizontal speed of the payload, while the regular speed of moving towards it is fine. I might need an xSpeed and ySpeed to accomplish this illusion.

        I do need an xSpeed and ySpeed. I need an angle between two vectors formula for the vector the payload is travelling on, and the vector of the distance
        from the payload to the enemy. Once the angle is calculated, I made a graphic for how the speed will be calculated based on the angle and the speed of the
        payload. Use Vector2.Angle(payloadVector, enemyVector);
    }
    */
    enum States
    {
       alive,
       dead
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(state == States.alive)
        {
            if (collision.gameObject.GetComponent<PayloadHealthSystem>() != null)
            {
                collision.gameObject.GetComponent<PayloadHealthSystem>().DecreaseHealth(damageValue);
            }
            else if (collision.gameObject.GetComponent<PlayerHealthSystem>() != null)
            {
                collision.gameObject.GetComponent<PlayerHealthSystem>().DecreaseHealth(damageValue);
            }
            else if (true)
            {
                Damage(1);
                Knockback(1); //PlayerShooter script has bools for what weapon is currently being used.
            }   
        }
    }

    void Damage(int amount)
    {
        healthSystem.DecreaseHealth(amount);
        if(healthSystem.GetHealth() > 0) //Health isn't zero
        {
            flash.FlashRed();
        }
        else
        {
            state = States.dead;
            flash.FadeBlack();
        }
    }

    public void Heal(int amount)
    {
        healthSystem.IncreaseHealth(amount);
        flash.FlashGreen();
    }
}

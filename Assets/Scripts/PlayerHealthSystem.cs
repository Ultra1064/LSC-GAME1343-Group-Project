using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{

       
    [SerializeField] private Sprite[] HealthBarSprites;
    [SerializeField] private SpriteRenderer healthBarSpriteRenderer;


    protected override void Start()
    {
        health = maxHealth;
    }

    public override void IncreaseHealth(int health)
    {
        if(this.health < maxHealth)
        this.health += health;
        UpdateHealthVisuals();
        Debug.Log("PlayerIncreaseHealth");
    }

    public override void DecreaseHealth(int health)
    {
        base.DecreaseHealth(health);
        UpdateHealthVisuals();
    }

        private void UpdateHealthVisuals()
    {
        if (healthBarSpriteRenderer != null)
        {
            if (health >= 60)
            healthBarSpriteRenderer.sprite = HealthBarSprites[0];
        else if (health >= 50)
            healthBarSpriteRenderer.sprite = HealthBarSprites[1]; 
        else if (health >= 40)
            healthBarSpriteRenderer.sprite = HealthBarSprites[2]; 
        else if (health >= 30)
            healthBarSpriteRenderer.sprite = HealthBarSprites[3]; 
        else if (health >= 20)
            healthBarSpriteRenderer.sprite = HealthBarSprites[4]; 
        else if (health >= 10)
            healthBarSpriteRenderer.sprite = HealthBarSprites[5]; 
        else
            healthBarSpriteRenderer.sprite = HealthBarSprites[6]; 
        }
        
    }
}

//"Hey, Angelo, why is the game over screen tied to the health bar instead of level manager?"
//I needed to directly tie the game over screen to how much health is left in the health system of both the player and payload.
//Level manager had no such values, so it must be done here.
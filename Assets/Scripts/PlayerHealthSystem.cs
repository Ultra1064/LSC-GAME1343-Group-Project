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
        Debug.Log("PlayerIncreaseHealth");
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
using UnityEngine;

public class PayloadHealthSystem : HealthSystem
{
    [SerializeField] private Sprite[] JeepGood;
    [SerializeField] private Sprite[] JeepDamaged;
    [SerializeField] private SpriteRenderer jeepSpriteRenderer;
    [SerializeField] private Sprite[] JeepHealthSprites;
    [SerializeField] private SpriteRenderer jeepHealthSpriteRenderer;
    protected override void FixedUpdate()
    {
        timeSinceLastDamaged += Time.deltaTime;
        if (timeSinceLastDamaged >= damagedCooldown)
            timeSinceLastDamaged = damagedCooldown;
        Debug.Log("Payload health: " + health);

    }
    public override void DecreaseHealth(int health)
    {
        base.DecreaseHealth(health);
        UpdateHealthVisuals();
    }

    private void UpdateHealthVisuals()
    {
        if (jeepHealthSpriteRenderer != null) 
        {
            if (health >= 100)
            {
                jeepHealthSpriteRenderer.sprite = JeepHealthSprites[0];
                jeepSpriteRenderer.sprite = JeepGood[0];
            }
            else if (health >= 75)
                jeepHealthSpriteRenderer.sprite = JeepHealthSprites[1];
            else if (health >= 50)
            {
                jeepHealthSpriteRenderer.sprite = JeepHealthSprites[2];
                jeepSpriteRenderer.sprite = JeepDamaged[0];
            }
            else if (health >= 25)
                jeepHealthSpriteRenderer.sprite = JeepHealthSprites[3];
            else
                jeepHealthSpriteRenderer.sprite = JeepHealthSprites[4];
        }

    }
}
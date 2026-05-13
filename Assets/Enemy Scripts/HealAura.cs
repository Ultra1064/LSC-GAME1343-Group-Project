using UnityEngine;

public class HealAura : MonoBehaviour
{
    [SerializeField] int healValue = 1; //The amount healed
    [SerializeField] float healInterval = 1.0f; //The amount of time required to stay inside the circle to be healed.
    private void OnTriggerStay2D(Collider2D collision) //For each enemy that stays inside the circle, a timer starts, and every time the timer exceeds the healInterval, an enemy is healed inside it.
    {
        if (collision.GetComponent<EnemyAI>()) //If it's not an enemy, none of this happens
        {
            float timer = 0;
            timer += Time.deltaTime;
            if (timer >= healInterval)
            {
                timer = 0;
                collision.GetComponent<EnemyAI>().Heal(healValue);
            }
        }
    }
}

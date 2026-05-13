using UnityEngine;

public class HealAura : MonoBehaviour
{
    [SerializeField] private int healValue = 1; //The amount healed
    [SerializeField] private float healInterval = 1.0f; //The amount of time required to stay inside the circle to be healed.
    private float timer = 0;

    void Update() //Update goes first, so it first increments the timer.
    {
        timer += Time.deltaTime;
    }
    void LateUpdate() //While Update and FixedUpdate are called FIRST every frame, LateUpdate is called LAST every frame, which in this case is HUGE since it calls AFTER OnTriggerStay2D and resets timer AFTER healing. 
    {  
        if (timer >= healInterval) //LastUpdate is last, finally resetting the timer after checking OnTriggerStay2D
        {
            timer = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //If an enemy is inside the circle when the timer hits the interval, they are healed!
    {
        if (collision.gameObject.GetComponent<EnemyAI>() != null) //If it's not an enemy, none of this happens
        {
            if (timer >= healInterval)
            {
                collision.GetComponent<EnemyAI>().Heal(healValue);
            }
        }
    }
}

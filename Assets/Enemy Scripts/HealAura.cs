using UnityEngine;

public class HealAura : MonoBehaviour
{
    [SerializeField] private int healValue = 1; //The amount healed
    [SerializeField] private float healInterval = 0.5f; //The amount of time required to stay inside the circle to be healed.
    private float timer = 0;
    private bool canHeal = false;
    void Update() //Update goes first, so it first increments the timer.
    {
        timer += Time.deltaTime;
        if (timer >= healInterval)
        {
            canHeal = true;
        }
    }
    /*void LateUpdate() //NO LONGER USING THIS //While Update and FixedUpdate are called FIRST every frame, LateUpdate is called LAST every frame, which in this case is HUGE since it calls AFTER OnTriggerStay2D and resets timer AFTER healing. 
    {
        Debug.Log("Late Update!");
        if (timer >= healInterval) //LastUpdate is last, finally resetting the timer after checking OnTriggerStay2D
        {
            timer = 0;
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision) //If an enemy is inside the circle when the timer hits the interval, they are healed!
    {
        if (collision.gameObject.GetComponent<EnemyAI>() != null) //If it's not an enemy, none of this happens
        {
            if (canHeal)
            {
                collision.GetComponent<EnemyAI>().Heal(healValue);
                canHeal = false; //Apparently this new method ONLY heals ONE guy, which is sad. Unsure how to fix.
                timer = 0;
            }
        }
    }
}

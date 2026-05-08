using UnityEngine;
using UnityEngine.Events;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float powerUpTimeTillDespawn = 5f;
    protected float powerUpCurrTimer = 0;
    protected virtual void FixedUpdate()
    {
        powerUpCurrTimer += Time.deltaTime;
        if (powerUpCurrTimer > powerUpTimeTillDespawn)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float powerUpTimeTillDespawn = 10f;
    protected float powerUpCurrTimer = 0;
    protected abstract void Awake();
    protected virtual void FixedUpdate()
    {
        powerUpCurrTimer += Time.deltaTime;
        if (powerUpCurrTimer > powerUpTimeTillDespawn)
        {
            Destroy(gameObject);
        }
    }
    protected abstract void OnTriggerEnter2D(Collider2D other);
}

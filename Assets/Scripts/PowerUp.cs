using UnityEngine;
using UnityEngine.Events;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float powerUpTimeTillDespawn = 10f;
    [SerializeField] protected AudioClip get;
    protected AudioSource source;
    protected float powerUpCurrTimer = 0;
    protected abstract void Awake();

    protected virtual void Start()
    {
        source = Object.FindFirstObjectByType<AudioSource>(); //Needed to add this for sound
    }
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

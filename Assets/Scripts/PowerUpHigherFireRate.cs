using UnityEngine;
using UnityEngine.Events;

public class PowerUpHigherFireRate : PowerUp
{
    [SerializeField] UnityEvent IncreaseFireRate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControls>() != null)
        {
            if (IncreaseFireRate != null)
                IncreaseFireRate.Invoke();
            Destroy(gameObject);
        }
    }
}
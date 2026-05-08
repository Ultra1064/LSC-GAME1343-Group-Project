using UnityEngine;
using UnityEngine.Events;

public class FireRatePowerUpOn : MonoBehaviour
{
    [SerializeField] UnityEvent<float> DivideFireRate;
    [SerializeField] UnityEvent StopFireRatePowerUp;
    [SerializeField] float rateToDivideBy = 2.0f;
    [SerializeField] float powerUpLifeSpan = 10f;

    private float currLifeSpan = 0f;
    private void Awake()
    {
        DivideFireRate.Invoke(rateToDivideBy);
    }
    private void FixedUpdate()
    {
        currLifeSpan += Time.deltaTime;
        if (currLifeSpan > powerUpLifeSpan)
            Destroy(gameObject.GetComponent<FireRatePowerUpOn>());
    }
    private void OnDestroy()
    {
        StopFireRatePowerUp.Invoke();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] int enemyDamage = 10;

    private UnityEvent<int> PlayerDamaged = new UnityEvent<int>();
    private UnityEvent<int> PayloadDamaged = new UnityEvent<int>();

    private PlayerHealthSystem playerHealth;
    private PayloadHealthSystem payloadHealth;
    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealthSystem>();
        payloadHealth = FindAnyObjectByType<PayloadHealthSystem>();

        PlayerDamaged.AddListener(playerHealth.DecreaseHealth);
        PayloadDamaged.AddListener(payloadHealth.DecreaseHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>() != null)
        {
            PlayerDamaged.Invoke(enemyDamage);
        }
        if (collision.GetComponent<PayloadHealthSystem>() != null)
        {
            Debug.Log("Payload Hit");
            PayloadDamaged.Invoke(enemyDamage);
        }
    }
}

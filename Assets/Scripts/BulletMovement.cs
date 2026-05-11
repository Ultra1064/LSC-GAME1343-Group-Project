using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class BulletMovement : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float bulletLifeSpan = 1f;
    [SerializeField] Rigidbody2D rb;

    private float bulletLife = 0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
        bulletLife += Time.deltaTime;
        if (bulletLife > bulletLifeSpan)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyIdentifier>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
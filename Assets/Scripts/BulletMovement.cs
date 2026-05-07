using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float bulletLifeSpan = 1f;
    [SerializeField] Rigidbody2D rb;

    private float bulletLife = 0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
        bulletLife += Time.deltaTime;
        if (bulletLife > bulletLifeSpan)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // For when Enemies have been implemented
    }
}
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using static Unity.VisualScripting.Member;

public class BulletMovement : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float bulletLifeSpan = 1f;
    [SerializeField] int bulletDamage = 10;
    [SerializeField] float bulletKnockback = 1.0f;
    [SerializeField] Rigidbody2D rb;

    private AudioSource source;
    [SerializeField] AudioClip fire;
    [SerializeField] AudioClip hit;

    private float bulletLife = 0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        source = Object.FindFirstObjectByType<AudioSource>(); //Needed to add this for sound
    }

    private void Start()
    {
        source.PlayOneShot(fire); //This plays a sound when a bullet is fired
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
        if (collision.GetComponent<EnemyAI>() != null)
        {
            if (collision.GetComponent<EnemyAI>().alive)
            {
                collision.GetComponent<EnemyAI>().Damage(bulletDamage); //Changed from collision.GetComponent<EnemyHealthSystem>().DecreaseHealth(bulletDamage); If Damage isn't called, the enemy won't flash red. -Victor
                collision.GetComponent<EnemyAI>().Knockback(bulletKnockback);
                source.PlayOneShot(hit); //This plays a sound when the bullet hits
                Destroy(gameObject);
            }
            
        }
    }
}
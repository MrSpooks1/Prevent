using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 40f;
    public Rigidbody2D rb;
    public float Lifetime = 0.3f;
    private float currentTime = 0;
    public float damage = 1;
    void Start()
    {
        rb.linearVelocity = transform.right * -Speed; // -speed => move left
    }
    void Update()
    {
        if (currentTime > Lifetime) Destroy(gameObject);
        currentTime += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Health enemyHealth = collision.GetComponent<Health>();
            enemyHealth?.ReduceHP(damage);
        }
    }
}

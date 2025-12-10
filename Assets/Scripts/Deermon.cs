using UnityEngine;

public class Deermon : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator Animator;
    private bool isFacingRight;
    public float moveSpeed;
    void Update()
    {
        if (PlayerController.Instance.BossFightStarted)
        {
            Animator.SetFloat("velocity", rb.linearVelocity.magnitude);
            if (rb.linearVelocity.x < -0.1)
            {
                if (isFacingRight) FLip();
                isFacingRight = false;
            }
            if (rb.linearVelocity.x > 0.1)
            {
                if (!isFacingRight) FLip();
                isFacingRight = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (PlayerController.Instance.BossFightStarted) rb.linearVelocity = GetDirection();
    }
    private Vector2 GetDirection()
    {
        Vector3 position1 = new Vector3(PlayerController.Instance.transform.position.x + 2, PlayerController.Instance.transform.position.y, 1);
        Vector3 position2 = new Vector3(PlayerController.Instance.transform.position.x - 2, PlayerController.Instance.transform.position.y, 1);
        if ((position1 - transform.position).magnitude < (position2 - transform.position).magnitude) return (position1 - transform.position).normalized * moveSpeed * Time.deltaTime;
        else return (position2 - transform.position).normalized * moveSpeed * Time.deltaTime;
    }
    private void FLip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") PlayerController.Instance.Die();
    }
}

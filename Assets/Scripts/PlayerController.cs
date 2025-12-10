using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public Rigidbody2D rb;
    public float PlayerMoveSpeed;
    public Animator Animator;
    private bool isFacingRight;
    public bool HasBurger;
    public bool HasBook;
    public bool HasCode;
    public bool BossFightStarted;
    public float TimeLimit;
    public bool isDead;
    private float currentTime;
    public static PlayerController Instance { get; private set; }
    private void Start()
    {
        Dialogue.Instance.PrepareDialogueLines(new[] { "Jim", "Something very bad is about to happen", "No time to explain", "Prevent it", "Or die" });
        Dialogue.Instance.StartDialogue();
        BossFightStarted = false;
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        currentTime = 0;
    }
    void Update()
    {
        currentTime += Time.deltaTime;
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
    private void FixedUpdate()
    {
        if (currentTime > TimeLimit && !BossFightStarted && !isDead) Die();
        rb.linearVelocity = GetDirection();
    }
    private Vector2 GetDirection()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        return new Vector2(horizontalInput * PlayerMoveSpeed, verticalInput * PlayerMoveSpeed) * Time.deltaTime;
    }
    private void FLip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
    public void Die()
    {
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

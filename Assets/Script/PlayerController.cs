using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float moveForce = 10f;
    public float jumpPower = 10f;
    public float maxHealth = 100f;
    public float currentHealth;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator am;
    private int jumpCharges;
    public int maxJumpCharges = 1;
    private bool isGrounded = false;
    private GameOverManager gameOverManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        am = GetComponent<Animator>();
        jumpCharges = maxJumpCharges;
        currentHealth = maxHealth;
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && jumpCharges > 0)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCharges--;
        }

        if (h != 0)
        {
            Vector2 force = new Vector2(h * moveForce, 0);
            rb.AddForce(force);
            sp.flipX = h < 0;
        }

        if (Mathf.Abs(rb.velocity.x) < 0.1f)
        {
            am.SetBool("Run", false);
        }
        else
        {
            am.SetBool("Run", true);
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        MeetGround();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCharges = maxJumpCharges;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void MeetGround(){
        if (isGrounded)
        {
            jumpCharges = maxJumpCharges;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameOverManager.GameOver();
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Dead"))
    {
        gameOverManager.GameOver();
        gameObject.SetActive(false);
    }
}
}
